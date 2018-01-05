using System;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Events.Resource;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class ResourceProject : Entity
    {
        public Guid ResourceId { get; protected set; }
        public Guid ProjectId { get; protected set; }

        public ResourceProject()
        {
            
        }
        public ResourceProject(ResourceToProjectShared @event)
        {
           Apply(@event);
        }

        public void Apply(ResourceToProjectShared @event)
        {
            this.ProjectId = @event.ProjectId;
            this.ResourceId = @event.ResourceId;
            this.Id = @event.Id;
        }

        public void Remove(RemoveResourceFromProjectCommand command, IDomainEventsService domainEventsService)
        {
            var @event = new ResourceFromProjectRemoved(command);
            domainEventsService.Publish(@event);
        }
    }
}