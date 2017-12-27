using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries
{
    public interface IOrganizationQuery
    {
        Task<IPagedList<Organization>> GetAllAsync();
        Task<Organization> GetAsync(Guid id);
        Task<Organization> GetAsync(string name);
        Task<IPagedList<User>> GetUsersAsync(Guid organizationId);
        Task<User> GetUserAsync(Guid organizationId, Guid userId);
    }
}