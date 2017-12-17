﻿using System.Collections.Generic;
using Autofac;
using MediatR;
using MyNote.Identity.API.Application.DomainHandler;
using MyNote.Identity.Infrastructure;
using MyNote.Identity.Infrastructure.SeedWork;
using MyNote.Identity.Infrastructure.Services;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.API.Infrastructure.Autofac
{
    public class DepedencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginService>()
                .As<ILoginService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RegisterService>()
                .As<IRegisterService>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(DataRepository<>))
                .As(typeof(IDataRepository<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(typeof(CreateFirstUserCommandHandler).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces();

            builder.RegisterType<OrganizationService>()
                .As<IOrganizationService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TimeService>()
                .As<ITimeService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}