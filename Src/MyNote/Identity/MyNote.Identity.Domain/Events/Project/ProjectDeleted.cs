using System;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Project
{
    public class ProjectDeleted : DomainEvent
    {
        public Guid ProjectId { get; set; }
        public Guid OrganizationId { get; set; }

        public ProjectDeleted(DeleteProjectCommand command)
        {
            this.OrganizationId = command.OrganizationId;
            this.ProjectId = command.ProjectId;
        }
    }
}