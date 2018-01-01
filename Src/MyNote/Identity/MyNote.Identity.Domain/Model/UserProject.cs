using MyNote.Identity.Domain.Events.User;
using System;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class UserProject : Entity
    {
        public Guid UserId { get; protected set; }
        public Guid ProjectId { get; protected set; }

        public UserProject()
        {

        }
        public UserProject(AddUserToProjectCommand command, IDomainEventsService domainEventsService)
        {
            var @event = new UserToProjectAdded(command);
            domainEventsService.Publish(@event);
            Apply(@event);
        }

        public void Apply(UserToProjectAdded @event)
        {
            this.ProjectId = @event.ProjectId;
            this.UserId = @event.UserId;
            this.Id = @event.Id;
        }

        public void Remove(RemoveUserFromProjectCommand command, IDomainEventsService domainEventsService)
        {
            var @event = new UserFromProjectRemoved(command);
            domainEventsService.Publish(@event);
        }

    }
}