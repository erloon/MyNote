using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyNote.Identity.API.Infrastructure;
using MyNote.Identity.API.Infrastructure.Autofac;
using MyNote.Identity.API.Infrastructure.Configs;
using MyNote.Identity.API.Infrastructure.Marten;
using MyNote.Identity.API.Infrastructure.Mediator;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure;
using RawRabbit.Configuration;
using RawRabbit.Configuration.Exchange;
using RawRabbit.DependencyInjection.Autofac;
using RawRabbit.Extensions.Client;
using Swashbuckle.AspNetCore.Swagger;

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
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    }))
                    .AddUnitOfWork<MyIdentityDbContext>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MyIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<AppSettings>(Configuration);
            services.AddAutoMapper(x => x.AddProfile(new ModelMapping()));
            services.AddRawRabbit();



            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Identity API", Version = "v1" });
                c.DescribeAllEnumsAsStrings();

            });


            var container = new ContainerBuilder();


            ConfigureContainer(container);
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterRawRabbit(new RawRabbitConfiguration()
            {
                Username = "guest",
                Password = "guest",
                VirtualHost = "/",
                Port = 5672,
                Hostnames = { "localhost" },
                RequestTimeout = new TimeSpan(0,0,0,10),
                PublishConfirmTimeout = new TimeSpan(0,0,0,10),
                RecoveryInterval = new TimeSpan(0,0,0,10),
                PersistentDeliveryMode = true,
                AutoCloseConnection = true,
                AutomaticRecovery = true,
                TopologyRecovery = true,
                Exchange = new GeneralExchangeConfiguration()
                {
                    
                    AutoDelete = true,
                    Durable = true,
                    Type = ExchangeType.Topic
                },
                
                Queue = new GeneralQueueConfiguration()
                {
                    AutoDelete = true,
                    Durable = true,
                    Exclusive = true
                }


            });

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
            app.UseStaticFiles();
            app.UseAuthentication();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/MyNote.Identity.API/swagger/v1/swagger.json", "Identity V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
