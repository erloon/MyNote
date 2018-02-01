using System;
using Autofac;
using Microsoft.Extensions.Configuration;
using MyNote.MVC.Application;

namespace MyNote.MVC.Infrastructure
{
    public class DepedencyModule : Module
    {
        private readonly IConfiguration _configuration;

        public DepedencyModule(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityService>()
                .As<IIdentityService>()
                .InstancePerLifetimeScope()
                .WithParameter("clientUrl", _configuration["IdentityServiceClient"]);

            builder.RegisterType<NoteService>()
                .As<INoteService>()
                .InstancePerLifetimeScope()
                .WithParameter("clientUrl", _configuration["NoteServiceClient"]);

            builder.RegisterType<StoreService>()
                .As<IStoreService>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}