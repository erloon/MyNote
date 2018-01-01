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
    public class ProjectQuery : IProjectQuery
    {
        private readonly IDataRepository<Project> _projectRepository;
        private readonly IDataRepository<User> _userRepository;

        public ProjectQuery(IDataRepository<Project> projectRepository,
                            IDataRepository<User> userRepository)
        {
            if (projectRepository == null) throw new ArgumentNullException(nameof(projectRepository));
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }
        public async Task<IPagedList<Project>> GetAllAsync(Guid organizationId)
        {
            return await _projectRepository.GetAsync(predicate: x => x.OrganizationId.Equals(organizationId));
        }

        public async Task<Project> GetAsync(Guid id, Guid organizationId)
        {
            return await _projectRepository.FirstOrDefaultAsync(
                predicate: x => x.OrganizationId.Equals(organizationId) && x.Id.Equals(id));
        }

        public async Task<Project> GetAsync(string name, Guid organizationId)
        {
            return await _projectRepository.FirstOrDefaultAsync(
                predicate: x => x.OrganizationId.Equals(organizationId) && x.Name.Equals(name));
        }

        public async Task<IPagedList<User>> GetUsersAsync(Guid projectId, Guid organizationId)
        {
            var project = await _projectRepository.FirstOrDefaultAsync(predicate: x => x.Id.Equals(projectId) && x.OrganizationId.Equals(organizationId),
                           include: i => i.Include(x => x.UserProjects))
                       ?? throw new DomainException("project not found", projectId);

            var ids = project.UserProjects.Select(x => x.UserId);

            return await _userRepository.GetAsync(predicate: x => ids.Contains(x.Id));
        }

        public async Task<User> GetUserAsync(Guid projectId, Guid userId, Guid organizationId)
        {

            var team = await _projectRepository.FirstOrDefaultAsync(predicate: x => x.Id.Equals(projectId) && x.OrganizationId.Equals(organizationId),
                           include: i => i.Include(x => x.UserProjects))
                       ?? throw new DomainException("team not found", projectId);

            var userProject = team.UserProjects.FirstOrDefault(x => x.UserId.Equals(userId))
                       ?? throw new DomainException("User not found", userId);

            return await _userRepository.FirstOrDefaultAsync(predicate: x => x.Id.Equals(userProject.UserId));
        }
    }
}