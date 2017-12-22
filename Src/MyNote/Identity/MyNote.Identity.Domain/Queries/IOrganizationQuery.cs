using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries
{
    public interface IOrganizationQuery
    {
        Task<IEnumerable<Organization>> GetAllAsync();
        Task<Organization> GetAsync(Guid id);
        Task<Organization> GetAsync(string name);
        Task<IEnumerable<User>> GetUsersAsync(Guid organizationId);
        Task<User> GetUserAsync(Guid organizationId, Guid userId);
    }
}