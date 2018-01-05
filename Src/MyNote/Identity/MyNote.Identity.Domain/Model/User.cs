using System;
using System.Collections.Generic;
using System.Linq;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Identity.Domain.Commands.Team;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Events.User;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class User : BaseEntity
    {
        public ApplicationUser ApplicationUser { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public bool IsAdministrator { get; protected set; }
        public bool IsConfirmByAdmin { get; protected set; }
        public virtual ICollection<UserTeam> UserTeams { get; protected set; }
        public virtual ICollection<UserProject> UserProjects { get; protected set; }
        public virtual ICollection<ResourceUser> ResourceUsers { get; protected set; }

        public User()
        {

        }
        public User(CreateUserCommand command, ApplicationUser applicationUser, Guid organizationId, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (applicationUser == null) throw new ArgumentNullException(nameof(applicationUser));
            if (organizationId == null) throw new ArgumentNullException(nameof(organizationId));

            var @event = new UserCreated(command, applicationUser, organizationId, timeService);
            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void Update(UpdateUserCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new UserUpdated(command, timeService);

            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void Delete(DeleteUserCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new UserDeleted(command);

            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void AddToTeam(AddUserToTeamCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var @event = new UserToTeamAdded(command);

            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void AddToProject(AddUserToProjectCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var userProject = new UserProject(command, domainEventsService);

            if (this.UserProjects == null) this.UserProjects = new List<UserProject>();
            this.UserProjects.Add(userProject);

        }

        public void RemoveFromTeam(RemoveUserFromTeamCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new UserFromTeamRemoved(command);
            var userTeam = this.UserTeams.FirstOrDefault(x => x.TeamId.Equals(command.TeamId)) ?? throw new DomainException("Team not found", command.TeamId);
            userTeam.Remove(command, domainEventsService);
            Apply(@event);
        }

        public void RemoveFromProject(RemoveUserFromProjectCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new UserFromProjectRemoved(command);
            var userProject = this.UserProjects.FirstOrDefault(x => x.ProjectId.Equals(command.ProjectId)) ??
                              throw new DomainException("Project not found", command.ProjectId);

            userProject.Remove(command, domainEventsService);
            Apply(@event);
        }

        #region Events apply methods

        public void Apply(UserCreated @event)
        {
            this.Id = @event.UserId;
            this.IsAdministrator = @event.IsAdministrator;
            this.ApplicationUser = @event.ApplicationUser;
            this.OrganizationId = @event.OrganizationId;
            this.CreateBy = @event.CreateBy;
            this.UpdateBy = @event.UpdateBy;
            this.Modification = @event.Modification;
            this.Create = @event.Create;
        }

        public void Apply(UserUpdated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.OrganizationId = @event.OrganizationId;
            this.Modification = @event.Modification;
        }

        public void Apply(UserToTeamAdded @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.UserTeams.Add(new UserTeam(@event));
        }

        public void Apply(UserFromTeamRemoved @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));
            var userTeam =
                this.UserTeams.FirstOrDefault(x => x.UserId.Equals(@event.UserId) && x.TeamId.Equals(@event.TeamId)) ??
                throw new DomainException("User in team not founded", @event.UserId);

            this.UserTeams.Remove(userTeam);
        }

        public void Apply(UserFromProjectRemoved @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));
            var userProject =
                this.UserProjects.FirstOrDefault(x => x.UserId.Equals(@event.UserId) && x.ProjectId.Equals(@event.ProjectId)) ??
                throw new DomainException("User in team not founded", @event.UserId);

            this.UserProjects.Remove(userProject);
        }

        public void Apply(UserDeleted @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));
        }
        #endregion


    }
}