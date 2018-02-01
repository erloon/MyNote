using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNote.MVC.Infrastructure;

namespace MyNote.MVC
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


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.Cookie = new CookieBuilder()
                    {
                        Name = ".AuthCookie",
                        Domain = "localhost",
                        SecurePolicy = CookieSecurePolicy.SameAsRequest,
                        SameSite = SameSiteMode.Lax,
                        HttpOnly = false,

                    };
                    o.LoginPath = new PathString("/Identity/Login");
                    o.LogoutPath = new PathString("/Identity/LogOut");
                });
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(@"/appdata"));
            services.AddMvc();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });

            var container = new ContainerBuilder();
            ConfigureContainer(container);
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }

        private void ConfigureContainer(ContainerBuilder container)
        {
            container.RegisterModule(new DepedencyModule(Configuration));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
