using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Events.Resource;
using MyNote.Identity.Domain.Events.User;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Exception;

namespace MyNote.Identity.Domain.Queries.Handlers
{
    public class ResourceEventHandler : INotificationHandler<ResourceToProjectShared>,
                                        INotificationHandler<ResourceToTeamShared>,
                                        INotificationHandler<ResourceToUserShared>,
                                        INotificationHandler<ResourceFromUserRemoved>,
                                        INotificationHandler<ResourceFromProjectRemoved>,
                                        INotificationHandler<ResourceFromTeamRemoved>
    {
        private readonly IDataRepository<Resource> _resourceRepository;
        private readonly IResourceQuery _resourceQuery;
        private readonly IDataRepository<ResourceUser> _resourceUserRepository;
        private readonly IDataRepository<ResourceProject> _resourceProjectRepository;
        private readonly IDataRepository<ResourceTeam> _resourceTeamRepository;

        public ResourceEventHandler(IDataRepository<Resource> resourceRepository,
                                    IResourceQuery resourceQuery,
                                    IDataRepository<ResourceUser> resourceUserRepository,
                                    IDataRepository<ResourceProject> resourceProjectRepository,
                                    IDataRepository<ResourceTeam> resourceTeamRepository)
        {
            if (resourceRepository == null) throw new ArgumentNullException(nameof(resourceRepository));
            if (resourceQuery == null) throw new ArgumentNullException(nameof(resourceQuery));
            if (resourceUserRepository == null) throw new ArgumentNullException(nameof(resourceUserRepository));
            if (resourceProjectRepository == null) throw new ArgumentNullException(nameof(resourceProjectRepository));
            if (resourceTeamRepository == null) throw new ArgumentNullException(nameof(resourceTeamRepository));

            _resourceRepository = resourceRepository;
            _resourceQuery = resourceQuery;
            _resourceUserRepository = resourceUserRepository;
            _resourceProjectRepository = resourceProjectRepository;
            _resourceTeamRepository = resourceTeamRepository;
        }

        public Task Handle(ResourceToProjectShared notification, CancellationToken cancellationToken)
        {
            var resource = _resourceQuery.GetAsync(notification.ResourceId, notification.OrganizationId)
                ?? throw new DomainException("Resource not found", notification.ResourceId);

            ResourceProject resourceProject = new ResourceProject(notification);
            _resourceProjectRepository.Add(resourceProject);
            _resourceProjectRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(ResourceToTeamShared notification, CancellationToken cancellationToken)
        {
            var resource = _resourceQuery.GetAsync(notification.ResourceId, notification.OrganizationId)
                           ?? throw new DomainException("Resource not found", notification.ResourceId);

            ResourceTeam resourceTeam = new ResourceTeam(notification);
            _resourceTeamRepository.Add(resourceTeam);
            _resourceTeamRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(ResourceToUserShared notification, CancellationToken cancellationToken)
        {
            var resource = _resourceQuery.GetAsync(notification.ResourceId, notification.OrganizationId)
                           ?? throw new DomainException("Resource not found", notification.ResourceId);

            ResourceUser resourceUser = new ResourceUser(notification);
            _resourceUserRepository.Add(resourceUser);
            _resourceUserRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(ResourceFromUserRemoved notification, CancellationToken cancellationToken)
        {

            var resourceUser =
                _resourceUserRepository.FirstOrDefault(
                    predicate: x => x.ResourceId.Equals(notification.ResourceId) &&
                                    x.UserId.Equals(notification.UserId))
                ?? throw new DomainException("Resource not found", notification.ResourceId);

            _resourceUserRepository.Delete(resourceUser);
            _resourceUserRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(ResourceFromProjectRemoved notification, CancellationToken cancellationToken)
        {
            var resourceProject = _resourceProjectRepository.FirstOrDefault(predicate: x => x.ProjectId.Equals(notification.ProjectId) && x.ResourceId.Equals(notification.ResourceId))
                                  ?? throw new DomainException("Resource not found", notification.ResourceId);

            _resourceProjectRepository.Delete(resourceProject);
            _resourceProjectRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(ResourceFromTeamRemoved notification, CancellationToken cancellationToken)
        {
            var resourceTeam = _resourceTeamRepository.FirstOrDefault(predicate: x => x.TeamId.Equals(notification.TeamId) && x.ResourceId.Equals(notification.ResourceId))
                ?? throw new DomainException("Resource not found", notification.ResourceId);

            _resourceTeamRepository.Delete(resourceTeam);
            _resourceTeamRepository.Save();
            return Task.CompletedTask;
        }
    }
}