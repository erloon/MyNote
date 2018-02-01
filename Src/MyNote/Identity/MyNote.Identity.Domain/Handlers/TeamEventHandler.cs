using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Identity.Domain.Events.Team;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Exception;

namespace MyNote.Identity.Domain.Handlers
{
    public class TeamEventHandler : INotificationHandler<TeamCreated>,
                                    INotificationHandler<TeamUpdated>,
                                    INotificationHandler<TeamDeleted>
    {
        private readonly IDataRepository<Team> _teamRepository;

        public TeamEventHandler(IDataRepository<Team> teamRepository)
        {
            if (teamRepository == null) throw new ArgumentNullException(nameof(teamRepository));
            _teamRepository = teamRepository;
        }
        public Task Handle(TeamCreated notification, CancellationToken cancellationToken)
        {
            if (notification == null) throw new ArgumentNullException(nameof(notification));

            Team team = new Team();
            team.Apply(notification);
            _teamRepository.Add(team);
            _teamRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(TeamUpdated notification, CancellationToken cancellationToken)
        {
            if (notification == null) throw new ArgumentNullException(nameof(notification));
            Team team = _teamRepository.GetById(notification.TeamId) ?? throw new DomainException("Team not found",notification.TeamId);
            team.Apply(notification);
            _teamRepository.Update(team);
            _teamRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(TeamDeleted notification, CancellationToken cancellationToken)
        {
            if (notification == null) throw new ArgumentNullException(nameof(notification));
            Team team = _teamRepository.GetById(notification.TeamId) ?? throw new DomainException("Team not found", notification.TeamId);
            _teamRepository.Delete(team);
            _teamRepository.Save();
            return Task.CompletedTask;
        }
    }
}