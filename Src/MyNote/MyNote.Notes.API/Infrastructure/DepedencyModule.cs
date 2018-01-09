using Autofac;
using MyNote.Notes.Domain.Queries;

namespace MyNote.Notes.API.Infrastructure
{
    public class DepedencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotesQuery>().As<INotesQuery>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}