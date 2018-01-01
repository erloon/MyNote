using System;
using MyNote.Identity.Domain.Commands.Team;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Team
{
    public class TeamUpdated : DomainEvent
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public Guid OrganizationId { get; set; }
        public DateTime Modification { get; set; }
        public Guid UpdateBy { get; set; }

        public TeamUpdated(UpdateTeamCommand command, ITimeService timeService)
        {
            this.TeamId = command.TeamId;
            this.Name = command.Name;
            this.BeginDate = command.BeginDate;
            this.UpdateBy = command.UpdateBy;
            this.Modification = timeService.GetCurrent();
            this.OrganizationId = command.OrganizationId;
        }
    }
}