using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries
{
    public interface ITeamQuery
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetAsync(Guid id);
        Task<Team> GetAsync(string name);
        Task<IEnumerable<User>> GetUsersAsync(Guid teamId, Guid organizationId);
        Task<User> GetUserAsync(Guid teamId, Guid userId, Guid organizationId);
    }
}