using Autofac;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;
using MyNote.Notes.Domain.Queries;
using MyNote.Notes.Domain.Repositories;

namespace MyNote.Notes.API.Infrastructure
{
    public class DepedencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotesQuery>().As<INotesQuery>().InstancePerLifetimeScope();
            builder.RegisterType<FIleQuery>().As<IFIleQuery>().InstancePerLifetimeScope();
            builder.RegisterType<ImageQuery>().As<IImageQuery>().InstancePerLifetimeScope();
            builder.RegisterType<NoteRepository>().As<INoteRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FileRepository>().As<IFileRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ImageRepository>().As<IImageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DomainEventsService>().As<IDomainEventsService>().InstancePerLifetimeScope();
            builder.RegisterType<TimeService>().As<ITimeService>().InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}