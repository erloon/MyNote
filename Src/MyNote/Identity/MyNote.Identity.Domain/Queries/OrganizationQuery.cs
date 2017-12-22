using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries
{
    public class OrganizationQuery : IOrganizationQuery
    {
        public Task<IEnumerable<Organization>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync(Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(Guid organizationId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}