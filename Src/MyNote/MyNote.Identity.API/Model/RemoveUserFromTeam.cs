using System;

namespace MyNote.Identity.API.Model
{
    public class RemoveUserFromTeam
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
    }
}