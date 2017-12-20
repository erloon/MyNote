using System;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Resource
{
    public class ResourceFromProjectRemoved : DomainEvent
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid ProjectId { get; set; }

        public ResourceFromProjectRemoved(RemoveResourceFromProjectCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            this.OwnerId = command.OwnerId;
            this.ResourceId = command.ResourceId;
            this.ProjectId = command.ProjectId;
        }
    }
}