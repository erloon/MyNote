using System;

namespace MyNote.Identity.Domain.Commands.Team
{
    public class AddUserToTeamCommand
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
    }
}