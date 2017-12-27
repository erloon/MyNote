using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Database;

namespace MyNote.Identity.Domain.Queries
{
    public class OrganizationQuery : IOrganizationQuery
    {
        private readonly IDataRepository<Organization> _organizationRepository;
        private readonly IDataRepository<User> _userRepository;

        public OrganizationQuery(IDataRepository<Organization> organizationRepository,
                                    IDataRepository<User> userRepository)
        {
            if (organizationRepository == null) throw new ArgumentNullException(nameof(organizationRepository));
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));

            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
        }
        public async Task<IPagedList<Organization>> GetAllAsync()
        {
            return await _organizationRepository.GetAsync();
        }

        public async Task<Organization> GetAsync(Guid id)
        {
            return await _organizationRepository.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Organization> GetAsync(string name)
        {
            return await _organizationRepository.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public async Task<IPagedList<User>> GetUsersAsync(Guid organizationId)
        {
            return await _userRepository.GetAsync(x => x.OrganizationId.Equals(organizationId));
        }

        public async Task<User> GetUserAsync(Guid organizationId, Guid userId)
        {
            return await _userRepository.FirstOrDefaultAsync(
                x => x.OrganizationId.Equals(organizationId) && x.Id.Equals(userId));
        }
    }
}