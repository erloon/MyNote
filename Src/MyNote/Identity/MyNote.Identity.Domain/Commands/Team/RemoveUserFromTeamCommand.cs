using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Team
{
    public class RemoveUserFromTeamCommand : BaseCommand
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
    }
}