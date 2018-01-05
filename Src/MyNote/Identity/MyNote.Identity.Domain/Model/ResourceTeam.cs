using System;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Events.Resource;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class ResourceTeam : Entity
    {
        public Guid ResourceId { get; protected set; }
        public Guid TeamId { get; protected set; }

        public ResourceTeam()
        {
            
        }
        public ResourceTeam(ResourceToTeamShared @event)
        {
            Apply(@event);
        }

        public void Apply(ResourceToTeamShared @event)
        {
            this.Id = @event.Id;
            this.ResourceId = @event.ResourceId;
            this.TeamId = @event.TeamId;
        }

        public void Remove(RemoveResourceFromTeamCommand command, IDomainEventsService domainEventsService)
        {
            var @event = new ResourceFromTeamRemoved(command);
            domainEventsService.Publish(@event);
        }

    }
}