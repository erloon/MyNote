using System;
using System.Collections.Generic;
using Marten.Events.Projections;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Identity.Domain.Events.Project;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class Project : BaseEntity
    {
        public string Name { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public string Subject { get; protected set; }
        public string Description { get; protected set; }
        public Guid OrganizationId { get; protected set; }

        public virtual ICollection<UserProject> UserProjects { get; protected set; }
        public virtual ICollection<ResourceProject> ResourceProjects { get; protected set; }

        public Project()
        {
        }

        public Project(CreateProjectCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            var @event = new ProjectCreated(command,timeService);
            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void Update(UpdateProjectCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var @event = new ProjectUpdated(command, timeService);

            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void Delete(DeleteProjectCommand command,
            IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new ProjectDeleted(command);

            domainEventsService.Save(@event);
            
        }

        public void Apply(ProjectUpdated @event)
        {
            this.Name = @event.Name;
            this.StartDate = @event.StartDate;
            this.Subject = @event.Subject;
            this.Description = @event.Description;
            this.OrganizationId = @event.OrganizationId;
            this.Modification = @event.Modification;
            this.UpdateBy = @event.UpdateBy;
        }

        public void Apply(ProjectCreated @event)
        {
            this.Id = @event.ProjectId;
            this.Name = @event.Name;
            this.StartDate = @event.StartDate;
            this.Subject = @event.Subject;
            this.Description = @event.Description;
            this.OrganizationId = @event.OrganizationId;
            this.Create = @event.Create;
            this.Modification = @event.Modification;
            this.CreateBy = @event.CreateBy;
            this.UpdateBy = @event.UpdateBy;
        }
    }
}