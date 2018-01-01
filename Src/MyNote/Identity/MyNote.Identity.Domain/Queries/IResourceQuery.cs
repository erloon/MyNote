using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries
{
    public interface IResourceQuery
    {
        Task<IPagedList<Resource>> GetAllAsync(Guid organizationId);
        Task<Resource> GetAsync(Guid id, Guid organizationId);
        Task<IPagedList<User>> GetUsersAsync(Guid resourceId, Guid organizationId);
        Task<User> GetUserAsync(Guid resourceId, Guid userId, Guid organizationId);
        Task<IEnumerable<Resource>> GetByTeamAsync(Guid teamId, Guid organizationId);
        Task<IEnumerable<Resource>> GetByProjectAsync(Guid projectId, Guid organizationId);
        Task<IEnumerable<Resource>> GetByUserAsync(Guid userId, Guid organizationId);


    }
}