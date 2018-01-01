using System;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Events.User;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class UserTeam : Entity
    {
        public Guid TeamId { get; protected set; }
       
        public Guid UserId { get; protected set; }

        public UserTeam()
        {

        }

        public UserTeam(UserToTeamAdded @event)
        {
            this.Id = @event.UserTeamId;
            this.TeamId = @event.TeamId;
            this.UserId = @event.UserId;
        }

        public void Apply(UserToTeamAdded @event)
        {
            this.Id = @event.UserTeamId;
            this.TeamId = @event.TeamId;
            this.UserId = @event.UserId;
        }

        public void Remove(RemoveUserFromTeamCommand command, IDomainEventsService domainEventsService)
        {
            var @event =new UserFromTeamRemoved(command);
            domainEventsService.Publish(@event);
        }
    }
    
}