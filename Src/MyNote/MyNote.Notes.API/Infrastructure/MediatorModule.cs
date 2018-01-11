using System.Collections.Generic;
using Autofac;
using Autofac.Features.Variance;
using MediatR;
using System.Reflection;
using MyNote.Notes.API.Application;
using MyNote.Notes.Domain.Commands;
using MyNote.Notes.Domain.Events;
using Module = Autofac.Module;


namespace MyNote.Notes.API.Infrastructure
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

            builder.RegisterType<CreateNoteCommand>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder
                .RegisterAssemblyTypes(typeof(NotesHandler).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(NoteCreated).GetTypeInfo().Assembly).AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}