using System;

namespace MyNote.Identity.Domain.Model
{
    public class UserTeam
    {
        public Guid TeamId { get; protected set; }
        public Team Team { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
    }
}