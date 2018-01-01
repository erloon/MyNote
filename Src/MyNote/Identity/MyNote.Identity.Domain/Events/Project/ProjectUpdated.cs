using System;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Project
{
    public class ProjectUpdated : DomainEvent
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }
        public DateTime Modification { get; set; }
        public Guid UpdateBy { get; set; }

        public ProjectUpdated(UpdateProjectCommand command, ITimeService timeService)
        {
            this.Name = command.Name;
            this.StartDate = command.StartDate;
            this.Subject = command.Subject;
            this.Description = command.Description;
            this.OrganizationId = command.OrganizationId;
            this.Modification = timeService.GetCurrent();
            this.UpdateBy = command.UpdateBy;
            this.ProjectId = command.ProjectId;
        }
    }
}