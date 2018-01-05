using System;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Events.Resource;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class ResourceUser : Entity
    {
        public Guid ResourceId { get; protected set; }
        public Guid UserId { get; protected set; }

        public ResourceUser()
        {

        }

        public ResourceUser(ResourceToUserShared @event)
        {
            Apply(@event);
        }

        public void Apply(ResourceToUserShared @event)
        {
            this.Id = @event.Id;
            this.ResourceId = @event.ResourceId;
            this.UserId = @event.UserId;
        }

        public void Remove(RemoveResourceFromUserCommand command, IDomainEventsService domainEventsService)
        {
            var @event = new ResourceFromUserRemoved(command);
            domainEventsService.Publish(@event);
        }
    }
}