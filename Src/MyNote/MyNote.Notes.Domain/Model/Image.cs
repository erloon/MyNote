using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;
using MyNote.Notes.Domain.Commands;
using MyNote.Notes.Domain.Events;

namespace MyNote.Notes.Domain.Model
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public Guid OrganizationId { get; set; }
        public byte[] Content { get; set; }

        public Image()
        {

        }

        public Image(CreateImageCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new ImageCreated(command, timeService);
            domainEventsService.Save(@event);

            Apply(@event);
        }

        public void Delete(DeleteImageCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));
            var @event = new ImageDeleted(command);
            domainEventsService.Save(@event);
        }
        public void Apply(ImageCreated @event)
        {
            this.Id = @event.ImageId;
            this.Name = @event.Name;
            this.Type = @event.Type;
            this.OrganizationId = @event.OrganizationId;
            this.Content = @event.Content;
            this.Create = @event.Create;
            this.Modification = @event.Modification;
            this.CreateBy = @event.CreateBy;
            this.UpdateBy = @event.UpdateBy;
        }
    }
}