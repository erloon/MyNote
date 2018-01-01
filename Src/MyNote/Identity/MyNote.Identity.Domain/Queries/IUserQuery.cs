using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries
{
    public interface IUserQuery
    {
        User Get(string name);

        Task<IPagedList<User>> GetAllAsync(Guid organizationId);
        Task<User> GetAsync(Guid id, Guid organizationId);
        Task<User> GetAsync(string name, Guid organizationId);
    }
}