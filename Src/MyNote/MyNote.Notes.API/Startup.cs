using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Marten;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyNote.Infrastructure.Model.EventBusRabbitMQ;
using MyNote.Notes.API.Infrastructure;
using RabbitMQ.Client;
using Swashbuckle.AspNetCore.Swagger;
using ConnectionFactory = RabbitMQ.Client.ConnectionFactory;
using Microsoft.Extensions.DependencyInjection;

namespace MyNote.Notes.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(x => x.AddProfile(new ModelMapping()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Notes API", Version = "v1" });
                c.DescribeAllEnumsAsStrings();

            });


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

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, retryCount);
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

           
            services.AddMvc();
            var container = new ContainerBuilder();

            services.Configure<AppSettings>(Configuration);
            ConfigureContainer(container);
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());
        }

        private void ConfigureContainer(ContainerBuilder builder)
        {
            var config = Configuration.GetSection("EventStore");
            builder.RegisterModule(new DepedencyModule());
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new MartenModule(config));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/MyNote.Notes.API/swagger/v1/swagger.json", "Notes V1");
            });
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();



        }
    }
}
