using System.Collections.Generic;
using Autofac;
using MediatR;
using System.Reflection;
using MyNote.Identity.Domain.Commands.User;
using Module = Autofac.Module;

namespace MyNote.Identity.API.Infrastructure.Mediator
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.Register<SingleInstanceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.Register<MultiInstanceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();

                return t =>
                {
                    var resolved = (IEnumerable<object>)componentContext.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                    return resolved;
                };
            });

            builder.RegisterAssemblyTypes(typeof(CreateFirstUserCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(RequestHandler<>));

            builder.RegisterAssemblyTypes(typeof(RegisterUserCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(RequestHandler<>));
            builder.RegisterAssemblyTypes(typeof(LoginCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(RequestHandler<>));

            base.Load(builder);
        }
    }
}