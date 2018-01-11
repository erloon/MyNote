using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;
using MyNote.Notes.Domain.Commands;
using MyNote.Notes.Domain.Events;

namespace MyNote.Notes.Domain.Model
{
    public enum FileType
    {
        PDF,
        TXT
    }
    public class File : BaseEntity
    {
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public decimal Size { get; set; }
        public string Path { get; set; }
        public byte[] Content { get; set; }
        public Guid OrganizationId { get; set; }

        public File()
        {

        }

        public File(CreateFileCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new FileCreated(command, timeService);
            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void Delete(DeleteFileCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));
            var @event = new FileDeleted(command);
            domainEventsService.Save(@event);

        }

        public void Apply(FileCreated @event)
        {
            this.Id = @event.FileId;
            this.OrganizationId = @event.OrganizationId;
            this.Name = @event.Name;
            this.FileType = @event.FileType;
            this.Size = @event.Size;
            this.Content = @event.Content;
            this.Create = @event.Create;
            this.Modification = @event.Modification;
            this.CreateBy = @event.CreateBy;
            this.UpdateBy = @event.UpdateBy;
        }


    }
}