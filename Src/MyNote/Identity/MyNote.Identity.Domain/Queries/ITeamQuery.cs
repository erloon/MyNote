using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries
{
    public interface ITeamQuery
    {
        Task<IPagedList<Team>> GetAllAsync(Guid organizationId);
        Task<Team> GetAsync(Guid id, Guid organizationId);
        Task<Team> GetAsync(string name, Guid organizationId);
        Task<IEnumerable<User>> GetUsersAsync(Guid teamId, Guid organizationId);
        Task<User> GetUserAsync(Guid teamId, Guid userId, Guid organizationId);
    }
}