using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Exception;

namespace MyNote.Identity.Domain.Queries
{
    public class TeamQuery : ITeamQuery
    {
        private readonly IDataRepository<Team> _teamRepository;
        private readonly IDataRepository<User> _userRepository;


        public TeamQuery(IDataRepository<Team> teamRepository,
                            IDataRepository<User> userRepository)
        {
            if (teamRepository == null) throw new ArgumentNullException(nameof(teamRepository));
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));

            _teamRepository = teamRepository;
            _userRepository = userRepository;
        }
        public async Task<IPagedList<Team>> GetAllAsync(Guid organizationId)
        {
            return await _teamRepository.GetAsync(predicate: x => x.OrganizationId.Equals(organizationId));
        }

        public async Task<Team> GetAsync(Guid id, Guid organizationId)
        {
            return await _teamRepository.FirstOrDefaultAsync(predicate: x => x.Id.Equals(id) && x.OrganizationId.Equals(organizationId));
        }

        public async Task<Team> GetAsync(string name, Guid organizationId)
        {
            return await _teamRepository.FirstOrDefaultAsync(predicate: x => x.Name.Equals(name) && x.OrganizationId.Equals(organizationId));
        }

        public async Task<IPagedList<User>> GetUsersAsync(Guid teamId, Guid organizationId)
        {
            var team = await _teamRepository.FirstOrDefaultAsync(predicate: x => x.Id.Equals(teamId) && x.OrganizationId.Equals(organizationId),
                include: i => i.Include(x => x.UserTeams))
                ?? throw new DomainException("team not found", teamId);

            var ids = team.UserTeams.Select(x => x.UserId);
            return await _userRepository.GetAsync(predicate: x => ids.Contains(x.Id));
        }

        public async Task<User> GetUserAsync(Guid teamId, Guid userId, Guid organizationId)
        {
            var team = await _teamRepository.FirstOrDefaultAsync(predicate: x => x.Id.Equals(teamId) && x.OrganizationId.Equals(organizationId),
                           include: i => i.Include(x => x.UserTeams))
                       ?? throw new DomainException("team not found", teamId);

            var userTeam = team.UserTeams.FirstOrDefault(x => x.UserId.Equals(userId))
                ?? throw new DomainException("User not found", userId);

            return await _userRepository.FirstOrDefaultAsync(predicate:x=>x.Id.Equals(userTeam.UserId));
        }
    }
}