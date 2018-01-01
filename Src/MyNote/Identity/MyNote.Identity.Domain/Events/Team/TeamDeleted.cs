using System;
using MyNote.Identity.Domain.Commands.Team;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Team
{
    public class TeamDeleted : DomainEvent

    {
        public Guid TeamId { get; set; }
        public Guid OrganizationId { get; set; }

        public TeamDeleted(DeleteTeamCommand command)
        {
            this.TeamId = command.TeamId;
            this.OrganizationId = command.OrganizationId;
        }
    }
}