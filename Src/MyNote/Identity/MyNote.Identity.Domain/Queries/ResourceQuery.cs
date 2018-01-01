using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Exception;

namespace MyNote.Identity.Domain.Queries
{
    public class ResourceQuery : IResourceQuery
    {
        private readonly IDataRepository<Resource> _resourceRepository;
        private readonly IDataRepository<User> _userRepository;

        public ResourceQuery(IDataRepository<Resource> resourceRepository,
                             IDataRepository<User> userRepository)
        {
            if (resourceRepository == null) throw new ArgumentNullException(nameof(resourceRepository));
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));

            _resourceRepository = resourceRepository;
            _userRepository = userRepository;
        }
        public async Task<IPagedList<Resource>> GetAllAsync(Guid organizationId)
        {
            return await _resourceRepository.GetAsync(predicate: x => x.OrganizationId.Equals(organizationId),
                include: i => i.Include(x => x.ResourceProjects).Include(x => x.ResourceTeams)
                    .Include(x => x.ResourceUsers));
        }

        public async Task<Resource> GetAsync(Guid id, Guid organizationId)
        {
            return await _resourceRepository.FirstOrDefaultAsync(predicate: x => x.OrganizationId.Equals(organizationId) && x.Id.Equals(id),
                 include: i => i.Include(x => x.ResourceProjects).Include(x => x.ResourceTeams)
                     .Include(x => x.ResourceUsers));
        }

        public async Task<IPagedList<User>> GetUsersAsync(Guid resourceId, Guid organizationId)
        {
            var resource = await GetAsync(resourceId, organizationId) ?? throw new DomainException("Resource not found", resourceId);

            var ids = resource.ResourceUsers.Select(x => x.UserId);

            return await _userRepository.GetAsync(predicate: x => ids.Contains(x.Id));
        }

        public async Task<User> GetUserAsync(Guid resourceId, Guid userId, Guid organizationId)
        {
            var resource = await GetAsync(resourceId, organizationId) ?? throw new DomainException("Resource not found", resourceId);

            var user = resource.ResourceUsers.FirstOrDefault(x => x.UserId.Equals(userId)) ?? throw new DomainException("User not found", userId);

            return await _userRepository.FirstOrDefaultAsync(predicate: x => x.Id.Equals(user));
        }

        public async Task<IEnumerable<Resource>> GetByTeamAsync(Guid teamId, Guid organizationId)
        {
            var resources = await _resourceRepository.GetAsync(predicate: x => x.OrganizationId.Equals(organizationId),
                include: i => i.Include(x => x.ResourceTeams));

            var ids = resources.Items.SelectMany(x => x.ResourceTeams.Where(t => t.TeamId.Equals(teamId))).Select(x => x.ResourceId);

            return resources.Items.Where(x => ids.Contains(x.Id));
        }

        public async Task<IEnumerable<Resource>> GetByProjectAsync(Guid projectId, Guid organizationId)
        {
            var resources = await _resourceRepository.GetAsync(predicate: x => x.OrganizationId.Equals(organizationId),
                include: i => i.Include(x => x.ResourceTeams));

            var ids = resources.Items.SelectMany(x => x.ResourceProjects.Where(t => t.ProjectId.Equals(projectId))).Select(x => x.ResourceId);

            return resources.Items.Where(x => ids.Contains(x.Id));
        }

        public async Task<IEnumerable<Resource>> GetByUserAsync(Guid userId, Guid organizationId)
        {
            var resources = await _resourceRepository.GetAsync(predicate: x => x.OrganizationId.Equals(organizationId),
                include: i => i.Include(x => x.ResourceTeams));

            var ids = resources.Items.SelectMany(x => x.ResourceUsers.Where(t => t.UserId.Equals(userId))).Select(x => x.ResourceId);

            return resources.Items.Where(x => ids.Contains(x.Id));
        }
    }
}