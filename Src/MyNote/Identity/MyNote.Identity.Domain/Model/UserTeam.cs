using System;
using MyNote.Identity.Domain.Events.User;

namespace MyNote.Identity.Domain.Model
{
    public class UserTeam
    {
        public Guid TeamId { get; protected set; }
        public Team Team { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }

        public UserTeam()
        {
            
        }

        public UserTeam(UserToTeamAdded @event)
        {
            this.TeamId = @event.TeamId;
            this.UserId = @event.UserId;
        }
    }
}