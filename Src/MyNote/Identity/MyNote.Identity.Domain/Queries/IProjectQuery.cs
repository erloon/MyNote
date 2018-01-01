using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries
{
    public interface IProjectQuery
    {
        Task<IPagedList<Project>> GetAllAsync(Guid organizationId);
        Task<Project> GetAsync(Guid id, Guid organizationId);
        Task<Project> GetAsync(string name, Guid organizationId);
        Task<IPagedList<User>> GetUsersAsync(Guid projectId, Guid organizationId);
        Task<User> GetUserAsync(Guid projectId, Guid userId, Guid organizationId);
    }
}