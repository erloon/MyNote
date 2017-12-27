using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries
{
    public class TeamQuery : ITeamQuery
    {
        public Task<IEnumerable<Team>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync(Guid teamId, Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(Guid teamId, Guid userId, Guid organizationId)
        {
            throw new NotImplementedException();
        }
    }
}