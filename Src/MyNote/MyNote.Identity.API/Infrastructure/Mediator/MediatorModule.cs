using System.Collections.Generic;
using Autofac;
using MediatR;
using System.Reflection;
using Autofac.Features.Variance;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Events.Organization;
using Module = Autofac.Module;

namespace MyNote.Identity.API.Infrastructure.Mediator
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterSource(new ContravariantRegistrationSource());

            builder
                .RegisterType<MediatR.Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder
                .Register<SingleInstanceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => { object o; return c.TryResolve(t, out o) ? o : null; };
                })
                .InstancePerLifetimeScope();

            builder
                .Register<MultiInstanceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                })
                .InstancePerLifetimeScope();

            builder.RegisterType<CreateOrganizationCommand>().AsImplementedInterfaces().InstancePerLifetimeScope();
           
            builder.RegisterAssemblyTypes(typeof(OrganizationCreated).GetTypeInfo().Assembly).AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}