using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Autofac;
using MediatR;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using MyNote.Identity.API.Infrastructure.Autofac;
using MyNote.Identity.API.Infrastructure.Configs;
using MyNote.Identity.API.Infrastructure.Marten;
using MyNote.Identity.API.Infrastructure.Mediator;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure;
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
