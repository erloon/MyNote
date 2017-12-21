using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class RemoveUserFromTeamCommand : Command
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
    }
}