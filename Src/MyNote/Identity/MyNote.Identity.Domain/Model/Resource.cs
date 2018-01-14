using System;
using System.Collections.Generic;
using System.Linq;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Events.Resource;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class Resource : BaseEntity
    {
        public string OwnerId { get; protected set; }
        public User Owner { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        //public Organization Organization { get; protected set; }
        public Guid? ContentId { get; protected set; }

        public virtual ICollection<ResourceUser> ResourceUsers { get; protected set; }
        public virtual ICollection<ResourceProject> ResourceProjects { get; protected set; }
        public virtual ICollection<ResourceTeam> ResourceTeams { get; protected set; }


        public Resource()
        {
        }

        public Resource(CreateResourceCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            var @event = new ResourceCreated(command, timeService);

            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void AddUser(ShareResourceToUserCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var @event = new ResourceToUserShared(command);
            domainEventsService.Save(@event);
            Apply(@event);

        }

        public void RemoveUser(RemoveResourceFromUserCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var resourceUser =
                this.ResourceUsers.FirstOrDefault(x => x.ResourceId.Equals(command.ResourceId) &&
                                                       x.UserId.Equals(command.UserId))
                    ?? throw new DomainException($"User {command.UserId} with resource {command.ResourceId} not found", command.ResourceId);

            var @event = new ResourceFromUserRemoved(command);
            resourceUser.Remove(command, domainEventsService);
            Apply(@event);
        }

        public void AddProject(ShareResourceToProjectCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            var @event = new ResourceToProjectShared(command);

            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void RemoveProject(RemoveResourceFromProjectCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            var @event = new ResourceFromProjectRemoved(command);

            var resourceProject = this.ResourceProjects.FirstOrDefault(x => x.ResourceId.Equals(command.ResourceId) &&
                                                                         x.ProjectId.Equals(command.ProjectId))
                                  ?? throw new DomainException($"Project {command.ProjectId} with resource {command.ResourceId} not found", command.ResourceId);

            resourceProject.Remove(command, domainEventsService);
            Apply(@event);
        }

        public void AddTeam(ShareResourceToTeamCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var @event = new ResourceToTeamShared(command);

            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void RemoveTeam(RemoveResourceFromTeamCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var @event = new ResourceFromTeamRemoved(command);
            var resourceeam = this.ResourceTeams.FirstOrDefault(x => x.ResourceId.Equals(command.ResourceId) &&
                                                                            x.TeamId.Equals(command.TeamId))
                                  ?? throw new DomainException($"Team {command.TeamId} with resource {command.ResourceId} not found", command.ResourceId);

            resourceeam.Remove(command, domainEventsService);
            Apply(@event);
        }

        #region Events apply

        public void Apply(ResourceCreated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.OrganizationId = @event.OrganizationId;
            this.Create = @event.Create;
            this.OwnerId = @event.OwnerId.ToString();
            this.ContentId = @event.ContentId;
            this.Id = @event.ResourceId;
            this.Modification = @event.Modification;
            this.CreateBy = @event.CreateBy;
            this.UpdateBy = @event.UpdateBy;
        }

        public void Apply(ResourceToUserShared @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.ResourceUsers.Add(new ResourceUser(@event));
        }

        public void Apply(ResourceFromUserRemoved @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            var item = this.ResourceUsers.FirstOrDefault(
                x => x.ResourceId.Equals(@event.ResourceId) && x.UserId.Equals(@event.UserId)) ?? throw new DomainException("Resource not belong to user", this.Id);

            this.ResourceUsers.Remove(item);
        }

        public void Apply(ResourceToProjectShared @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));


            this.ResourceProjects.Add(new ResourceProject(@event));
        }

        public void Apply(ResourceFromProjectRemoved @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            var item = this.ResourceProjects.FirstOrDefault(
                           x => x.ResourceId.Equals(@event.ResourceId) && x.ProjectId.Equals(@event.ProjectId)) ?? throw new DomainException("Resource not belong to project", this.Id);

            this.ResourceProjects.Remove(item);
        }

        public void Apply(ResourceToTeamShared @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.ResourceTeams.Add(new ResourceTeam(@event));
        }

        public void Apply(ResourceFromTeamRemoved @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            var item = this.ResourceTeams.FirstOrDefault(
                           x => x.ResourceId.Equals(@event.ResourceId) && x.TeamId.Equals(@event.TeamId)) ?? throw new DomainException("Resource not belong to team", this.Id);

            this.ResourceTeams.Remove(item);
        }
        #endregion

    }
}