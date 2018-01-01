using System;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.User
{
    public class UserToProjectAdded : DomainEvent
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid UserProjectId { get; set; }
        public UserToProjectAdded(AddUserToProjectCommand command)
        {
            this.UserProjectId = Guid.NewGuid();
            this.ProjectId = command.ProjectId;
            this.UserId = command.UserId;
            this.OrganizationId = command.OrganizationId;
        }
    }
}