using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Identity.Domain.Commands.Team;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Events.User;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class User : BaseEntity
    {
        public ApplicationUser ApplicationUser { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public Organization Organization { get; protected set; }
        public bool IsAdministrator { get; protected set; }
        public bool IsConfirmByAdmin { get; protected set; }
        public virtual ICollection<UserTeam> UserTeams { get; protected set; }
        public virtual ICollection<UserProject> UserProjects { get; protected set; }
        public virtual ICollection<ResourceUser> ResourceUsers { get; protected set; }

        public User()
        {
        }
        public User(CreateUserCommand command, ApplicationUser applicationUser, Guid organizationId, ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (applicationUser == null) throw new ArgumentNullException(nameof(applicationUser));
            if (organizationId == null) throw new ArgumentNullException(nameof(organizationId));

            var @event = new UserCreated(command, applicationUser, organizationId, timeService);
            Append(@event);
            Apply(@event);
        }

        public void Update(UpdateUserCommand command, ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            var @event = new UserUpdated(command, timeService);

            Append(@event);
            Apply(@event);
        }

        public void AddToTeam(AddUserToTeamCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var @event = new UserToTeamAdded(command);
            Append(@event);
            Apply(@event);
        }

        public void AddToProject(AddUserToProjectCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var @event = new UserToProjectAdded(command);

            Append(@event);
            Apply(@event);
        }

        #region Events apply methods

        public void Apply(UserCreated @event)
        {
            this.Id = @event.UserId;
            this.IsAdministrator = @event.IsAdministrator;
            this.ApplicationUser = @event.ApplicationUser;
            this.OrganizationId = @event.OrganizationId;
            this.Create = @event.Create;
        }

        public void Apply(UserUpdated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.OrganizationId = @event.OrganizationId;
            this.ApplicationUser = @event.ApplicationUser;
            this.Modification = @event.Modification;
        }

        public void Apply(UserToTeamAdded @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.UserTeams.Add(new UserTeam(@event));
        }

        public void Apply(UserToProjectAdded @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.UserProjects.Add(new UserProject(@event));
        }
        #endregion


    }
}