using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Commands.Team;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Events.Team;
using MyNote.Identity.Domain.Events.User;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class Team : BaseEntity
    {
        public string Name { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public Guid OwnerId { get; protected set; }
        public ApplicationUser User { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public virtual ICollection<UserTeam> UserTeams { get; protected set; }
        public virtual ICollection<ResourceTeam> ResourceTeams { get; protected set; }

        public Team(CreateTeamCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new TeamCreated(command, timeService);
            domainEventsService.Save(@event);
            Apply(@event);
        }

        public Team()
        {

        }

        public void Update(UpdateTeamCommand command, IDomainEventsService domainEventsService, ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            var @event = new TeamUpdated(command, timeService);
            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void Delete(DeleteTeamCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new TeamDeleted(command);
            domainEventsService.Save(@event);
        }

        public void Apply(TeamCreated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.Id = @event.TeamId;
            this.Name = @event.Name;
            this.CreateDate = @event.CreateDate;
            this.OwnerId = @event.OwnerId;
            this.CreateBy = @event.CreateBy.Value;
            this.UpdateBy = @event.UpdateBy.Value;
            this.Create = @event.Create;
            this.Modification = @event.Modification;
            this.OrganizationId = @event.OrganizationId;

        }

        public void Apply(TeamUpdated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.Name = @event.Name;
            this.CreateDate = @event.BeginDate;
            this.UpdateBy = @event.UpdateBy;
            this.Modification = @event.Modification;
        }


    }
}