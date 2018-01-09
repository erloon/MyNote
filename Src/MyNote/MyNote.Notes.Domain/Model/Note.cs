using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;
using MyNote.Notes.Domain.Commands;
using MyNote.Notes.Domain.Events;

namespace MyNote.Notes.Domain.Model
{
    public class Note : Aggregate
    {
        public string Name { get; protected set; }
        public Category Category { get; protected set; }
        public string Title { get; protected set; }
        public string Subject { get; protected set; }
        public Image HeaderImage { get; protected set; }
        public virtual List<Guid> Images { get; protected set; }
        public string ShortDescription { get; protected set; }
        public string Content { get; protected set; }
        public int Version { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public bool IsFinal { get; protected set; }
        public Guid OwnerId { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public virtual List<Guid> Files { get; protected set; }

        public Note()
        {

        }

        public Note(CreateNoteCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new NoteCreated(command, timeService);
            domainEventsService.Publish(@event);
            Apply(@event);
        }

        public void Update(UpdateNoteCommand command, ITimeService timeService,
            IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new NoteUpdated(command, timeService);
            domainEventsService.Publish(@event);
            Apply(@event);
        }

        public void Delete(DeleteNoteCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new NoteDeleted(command);
            domainEventsService.Publish(@event);
        }

        public void Apply(NoteCreated @event)
        {
            this.Id = @event.NoteId;
            this.Name = @event.Name;
            this.Category = new Category()
            {
                Id = @event.CategoryId
            };
            this.Title = @event.Title;
            this.ShortDescription = @event.ShortDescription;
            this.Subject = @event.Subject;
            this.Content = @event.Content;
            this.OwnerId = @event.OwnerId;
            this.OrganizationId = @event.OrganizationId;
            this.Create = @event.Create;
            this.Modification = @event.Modification;
            this.CreateBy = @event.CreateBy;
            this.UpdateBy = @event.UpdateBy;

            if (this.Files == null) this.Files = new List<Guid>();
            this.Files.AddRange(@event.Files);

            if (this.Images == null) this.Images = new List<Guid>();
            this.Images.AddRange(@event.Images);

        }

        public void Apply(NoteUpdated @event)
        {
            this.Name = @event.Name;
            this.Category = new Category()
            {
                Id = @event.CategoryId
            };
            this.Title = @event.Title;
            this.ShortDescription = @event.ShortDescription;
            this.Subject = @event.Subject;
            this.Content = @event.Content;
            this.OwnerId = @event.OwnerId;
            this.OrganizationId = @event.OrganizationId;
            this.Modification = @event.Modification;
            this.UpdateBy = @event.UpdateBy;

            if (this.Files == null) this.Files = new List<Guid>();
            this.Files.AddRange(@event.Files);

            if (this.Images == null) this.Images = new List<Guid>();
            this.Images.AddRange(@event.Images);

        }


    }
}