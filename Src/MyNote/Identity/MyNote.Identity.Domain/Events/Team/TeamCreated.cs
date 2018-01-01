using System;
using MediatR;
using MyNote.Identity.Domain.Commands.Team;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Team
{
    public class TeamCreated: DomainEvent
    {
        public string Name { get; set; }
        public Guid OrganizationId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? CreateBy { get; set; }
        public Guid? UpdateBy { get; set; }
        public Guid TeamId { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }

        public TeamCreated(CreateTeamCommand command, ITimeService timeService)
        {
            this.TeamId = Guid.NewGuid();
            this.Name = command.Name;
            this.CreateDate = command.CreateDate;
            this.OwnerId = command.OwnerId;
            this.CreateBy = command.CreateBy.Value;
            this.UpdateBy = command.UpdateBy.Value;
            this.Create = timeService.GetCurrent();
            this.Modification = timeService.GetCurrent();
            this.OrganizationId = command.OrganizationId;
        }
    }
}