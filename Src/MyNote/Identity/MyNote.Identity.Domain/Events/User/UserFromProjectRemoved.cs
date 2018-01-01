using System;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.User
{
    public class UserFromProjectRemoved : DomainEvent
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }

        public UserFromProjectRemoved(RemoveUserFromProjectCommand command)
        {
            this.ProjectId = command.ProjectId;
            this.UserId = command.UserId;
            this.OrganizationId = command.OrganizationId;
        }
    }
}