using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyNote.Notes.API.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddMvc();
            services.AddAutoMapper(x => x.AddProfile(new ModelMapping()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Notes API", Version = "v1" });
                c.DescribeAllEnumsAsStrings();

            });

            var container = new ContainerBuilder();


            ConfigureContainer(container);
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());
        }

        private void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DepedencyModule());
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new MartenModule(Configuration.GetSection("EventStore")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseStaticFiles();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/MyNote.Notes.API/swagger/v1/swagger.json", "Notes V1");
            });
        }
    }
}
