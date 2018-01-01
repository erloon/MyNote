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

        public TeamQuery(IDataRepository<Team> teamRepository,
                         IDataRepository<User> userRepository)
        {
            if (teamRepository == null) throw new ArgumentNullException(nameof(teamRepository));
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));

            _teamRepository = teamRepository;
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

        public async Task<IEnumerable<User>> GetUsersAsync(Guid teamId, Guid organizationId)
        {
            var team = await _teamRepository.FirstOrDefaultAsync(predicate: x => x.Id.Equals(teamId) && x.OrganizationId.Equals(organizationId),
                include: i => i.Include(x => x.UserTeams))
                ?? throw new DomainException("team not found", teamId);
            return team.UserTeams.Select(x => x.User);
        }

        public async Task<User> GetUserAsync(Guid teamId, Guid userId, Guid organizationId)
        {
            var team = await _teamRepository.FirstOrDefaultAsync(predicate: x => x.Id.Equals(teamId) && x.OrganizationId.Equals(organizationId),
                           include: i => i.Include(x => x.UserTeams).Include(u => u.UserTeams.Select(x => x.User)))
                       ?? throw new DomainException("team not found", teamId);

            var user = team.UserTeams.FirstOrDefault(x => x.UserId.Equals(userId)).User
                ?? throw new DomainException("User not found", userId);

            return user;
        }
    }
}