using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyNote.Identity.API.Application;
using MyNote.Identity.API.Infrastructure;
using MyNote.Identity.API.Infrastructure.Autofac;
using MyNote.Identity.API.Infrastructure.Configs;
using MyNote.Identity.API.Infrastructure.Marten;
using MyNote.Identity.API.Infrastructure.Mediator;
using MyNote.Identity.Domain.IntegrationEvents;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure;
using MyNote.Infrastructure.Model.EventBusRabbitMQ;
using RabbitMQ.Client;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace MyNote.Identity.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionString"];


            services.AddDbContext<MyIdentityDbContext>(options =>
                    options.UseSqlServer(connectionString,
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorNumbersToAdd: null);
                        }))
                .AddUnitOfWork<MyIdentityDbContext>();


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MyIdentityDbContext>()
                .AddDefaultTokenProviders();

            var directory = new DirectoryInfo("C:\\KeyRing");
            services.ConfigureApplicationCookie(options =>
            {
                var protectionProvider = DataProtectionProvider.Create(directory);

                options.Cookie.Name = ".AspNet.SharedCookie";
                options.DataProtectionProvider = protectionProvider;
                options.TicketDataFormat =
                    new TicketDataFormat(
                        protectionProvider.CreateProtector(
                            "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware",
                            "Cookies",
                            "v2"));
            });


            services.Configure<AppSettings>(Configuration);
            services.AddAutoMapper(x => x.AddProfile(new ModelMapping()));
            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope,
                    eventBusSubcriptionsManager, retryCount);
            });
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersisterConnection>>();
                var config = Configuration.GetSection("RawRabbit");
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };

                factory.UserName = "guest";
                factory.Password = "guest";
                var retryCount = 5;

                return new DefaultRabbitMQPersisterConnection(factory, logger, retryCount);
            });
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            services.AddTransient<NoteIntegrationEventHandler>();
            services.AddMvc();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = ".AspNet.SharedCookie";
                    options.DataProtectionProvider = DataProtectionProvider.Create(directory);
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "Identity API", Version = "v1"});
                c.DescribeAllEnumsAsStrings();

            });

            var container = new ContainerBuilder();
            ConfigureContainer(container);
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DepedencyModule());
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new MartenModule(Configuration.GetSection("EventStore")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            app.UseAuthentication();

            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                loggerFactory.CreateLogger("init").LogDebug($"Using PATH BASE '{pathBase}'");
                app.UsePathBase(pathBase);
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/MyNote.Identity.API/swagger/v1/swagger.json", "Identity V1");
            });
            ConfigureEventBus(app);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<NoteCreated, NoteIntegrationEventHandler>();

        }
    }
}
