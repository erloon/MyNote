using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Identity.Domain.Events.User;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Exception;

namespace MyNote.Identity.Domain.Handlers
{
    public class UserEventHandler : INotificationHandler<UserCreated>,
                                    INotificationHandler<UserUpdated>,
                                    INotificationHandler<UserDeleted>,
                                    INotificationHandler<UserToProjectAdded>,
                                    INotificationHandler<UserFromProjectRemoved>,
                                    INotificationHandler<UserToTeamAdded>,
                                    INotificationHandler<UserFromTeamRemoved>
    {
        private readonly IDataRepository<User> _userRepository;
        private readonly IUserQuery _userQuery;
        private readonly IDataRepository<UserTeam> _userTeamRepository;
        private readonly IDataRepository<UserProject> _userProjectRepository;

        public UserEventHandler(IDataRepository<User> userRepository,
                                IUserQuery userQuery,
                                IDataRepository<UserTeam> userTeamRepository,
                                IDataRepository<UserProject> userProjectRepository)
        {
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));
            if (userQuery == null) throw new ArgumentNullException(nameof(userQuery));
            if (userTeamRepository == null) throw new ArgumentNullException(nameof(userTeamRepository));
            if (userProjectRepository == null) throw new ArgumentNullException(nameof(userProjectRepository));

            _userRepository = userRepository;
            _userQuery = userQuery;
            _userTeamRepository = userTeamRepository;
            _userProjectRepository = userProjectRepository;
        }
        public Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            User user = new User();
            user.Apply(notification);
            _userRepository.Add(user);
            _userRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(UserUpdated notification, CancellationToken cancellationToken)
        {
            var user = _userQuery.GetAsync(notification.UserId, notification.OrganizationId).Result
                ?? throw new DomainException("User not found", notification.UserId);

            user.Apply(notification);
            _userRepository.Update(user);
            _userRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(UserDeleted notification, CancellationToken cancellationToken)
        {
            var user = _userQuery.GetAsync(notification.UserId, notification.OrganizationId).Result
                       ?? throw new DomainException("User not found", notification.UserId);

            user.Apply(notification);
            _userRepository.Delete(user);
            _userRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(UserToProjectAdded notification, CancellationToken cancellationToken)
        {
            var user = _userQuery.GetAsync(notification.UserId, notification.OrganizationId).Result
                       ?? throw new DomainException("User not found", notification.UserId);

            UserProject userProject = new UserProject();
            userProject.Apply(notification);
            _userProjectRepository.Add(userProject);
            _userProjectRepository.Save();

            return Task.CompletedTask;
        }

        public Task Handle(UserFromProjectRemoved notification, CancellationToken cancellationToken)
        {
            var user = _userQuery.GetAsync(notification.UserId, notification.OrganizationId).Result
                       ?? throw new DomainException("User not found", notification.UserId);

            var userProject =
                _userProjectRepository.FirstOrDefault(
                    predicate: x => x.UserId.Equals(user.Id) && x.ProjectId.Equals(notification.ProjectId));

            _userProjectRepository.Delete(userProject);
            _userProjectRepository.Save();

            return Task.CompletedTask;
        }

        public Task Handle(UserToTeamAdded notification, CancellationToken cancellationToken)
        {
            var user = _userQuery.GetAsync(notification.UserId, notification.OrganizationId).Result
                       ?? throw new DomainException("User not found", notification.UserId);

            UserTeam userTeam = new UserTeam(notification);
            _userTeamRepository.Add(userTeam);
            _userTeamRepository.Save();

            return Task.CompletedTask;
        }

        public Task Handle(UserFromTeamRemoved notification, CancellationToken cancellationToken)
        {
            var user = _userQuery.GetAsync(notification.UserId, notification.OrganizationId).Result
                       ?? throw new DomainException("User not found", notification.UserId);

            var userTeam = _userTeamRepository.FirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id) && x.TeamId.Equals(notification.TeamId)).Result;
            _userTeamRepository.Delete(userTeam);
            _userRepository.Save();
            return Task.CompletedTask;
        }
    }
}