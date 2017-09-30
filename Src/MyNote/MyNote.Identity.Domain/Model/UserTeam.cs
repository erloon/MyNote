using System;

namespace MyNote.Identity.Domain.Model
{
    public class UserTeam
    {
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}