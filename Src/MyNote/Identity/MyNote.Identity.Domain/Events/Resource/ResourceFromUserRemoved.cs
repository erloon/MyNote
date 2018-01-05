using System;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Resource
{
    public class ResourceFromUserRemoved : DomainEvent
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }

        public ResourceFromUserRemoved(RemoveResourceFromUserCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            this.OrganizationId = command.OrganizationId;
            this.OwnerId = command.OwnerId;
            this.ResourceId = command.ResourceId;
            this.UserId = command.UserId;
        }
    }
}