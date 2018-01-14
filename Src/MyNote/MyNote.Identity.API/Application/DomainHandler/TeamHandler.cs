using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Identity.Domain.Commands.Team;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.API.Application.DomainHandler
{
    public class TeamHandler : IRequestHandler<CreateTeamCommand, Team>,
                                IRequestHandler<UpdateTeamCommand, Team>,
                                IRequestHandler<DeleteTeamCommand, bool>


    {
        private readonly IDomainEventsService _domainEventsService;
        private readonly ITeamQuery _teamQuery;
        private readonly ITimeService _timeService;

        public TeamHandler(IDomainEventsService domainEventsService,
                            ITeamQuery teamQuery,
                            ITimeService timeService)
        {
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));
            if (teamQuery == null) throw new ArgumentNullException(nameof(teamQuery));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            _domainEventsService = domainEventsService;
            _teamQuery = teamQuery;
            _timeService = timeService;
        }
        public Task<Team> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            Team team = new Team(request, _timeService, _domainEventsService);
            return Task.FromResult(team);
        }

        public async Task<Team> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var team = await _teamQuery.GetAsync(request.TeamId, request.OrganizationId) ?? throw new DomainException("Team not found", request.TeamId);
            team.Update(request, _domainEventsService, _timeService);
            return await Task.FromResult(team);
        }

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var team = await _teamQuery.GetAsync(request.TeamId, request.OrganizationId) ?? throw new DomainException("Team not found", request.TeamId);
            team.Delete(request, _domainEventsService);
            return await Task.FromResult(true);
        }

    }
}