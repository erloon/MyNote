using System;

namespace MyNote.Identity.Domain.Model
{
    public class UserTeam
    {
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}