using System;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Project
{
    public class ProjectCreated : DomainEvent
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }
        public DateTime Create { get; set; }

        public ProjectCreated(CreateProjectCommand command, ITimeService timeService)
        {
            this.Name = command.Name;
            this.StartDate = command.StartDate;
            this.Subject = command.Subject;
            this.Description = command.Description;
            this.OrganizationId = OrganizationId;
            this.Create = timeService.GetCurrent();
        }
    }
}