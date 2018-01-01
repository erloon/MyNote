using System;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.User
{
    public class UserDeleted : DomainEvent
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }

        public UserDeleted(DeleteUserCommand command)
        {
            this.OrganizationId = command.OrganizationId;
            this.UserId = command.UserId;
        }
    }
}