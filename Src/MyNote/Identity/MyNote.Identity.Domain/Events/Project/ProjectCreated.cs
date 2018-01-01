using System;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Project
{
    public class ProjectCreated : DomainEvent
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }

        public ProjectCreated(CreateProjectCommand command, ITimeService timeService)
        {
            this.ProjectId = Guid.NewGuid();
            this.Name = command.Name;
            this.StartDate = command.StartDate;
            this.Subject = command.Subject;
            this.Description = command.Description;
            this.OrganizationId = command.OrganizationId;
            this.CreateBy = command.CreateBy;
            this.UpdateBy = command.UpdateBy;
            this.Create = timeService.GetCurrent();
            this.Modification = timeService.GetCurrent();
        }
    }
}