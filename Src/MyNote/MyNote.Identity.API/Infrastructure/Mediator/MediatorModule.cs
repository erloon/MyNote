using System.Collections.Generic;
using Autofac;
using MediatR;
using System.Reflection;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Events.Address;
using MyNote.Identity.Domain.Events.Company;
using MyNote.Identity.Domain.Events.Organization;
using MyNote.Identity.Domain.Events.User;
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

            builder.RegisterAssemblyTypes(typeof(CreateOrganizationCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(RequestHandler<>));
            builder.RegisterAssemblyTypes(typeof(CreateAddressCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(RequestHandler<>));
            builder.RegisterAssemblyTypes(typeof(CreateCompanyCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(RequestHandler<>));
            builder.RegisterAssemblyTypes(typeof(CreateUserCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(RequestHandler<>));


            builder.RegisterAssemblyTypes(typeof(OrganizationCreated).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(OrganizationUpdated).GetTypeInfo().Assembly).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(typeof(OrganizationCreated).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(NotificationHandler<>));
            //builder.RegisterAssemblyTypes(typeof(AddressCreated).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(NotificationHandler<>));
            //builder.RegisterAssemblyTypes(typeof(CompanyCreated).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(NotificationHandler<>));
            //builder.RegisterAssemblyTypes(typeof(UserCreated).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(NotificationHandler<>));

            base.Load(builder);
        }
    }
}