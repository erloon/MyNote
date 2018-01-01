using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using MyNote.Identity.Domain;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model.Database;

namespace MyNote.Identity.Infrastructure.Services
{
    public class OrganizationContextService : IOrganizationContextService
    {
        private readonly IUserQuery _userQuery;
        private readonly IOrganizationQuery _organizationQuery;

        public OrganizationContextService(IUserQuery userQuery,
                                          IOrganizationQuery organizationQuery)
        {
            if (userQuery == null) throw new ArgumentNullException(nameof(userQuery));
            if (organizationQuery == null) throw new ArgumentNullException(nameof(organizationQuery));

            _userQuery = userQuery;
            _organizationQuery = organizationQuery;
        }
        public async Task<OrganizationContext> Get(string userName)
        {
            User user = null;

            user = _userQuery.Get(userName);

            var context = new OrganizationContext()
            {
                UserId = user.Id,
                OrganizationId = user.OrganizationId,
                ProjectsOwnership = GetProjects(user),
                TeamsOwnership = GetTeams(user)
            };
            return context;
        }

        private List<Guid> GetTeams(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            List<Guid> result = new List<Guid>();

            if (user.UserTeams.IsNullOrEmpty()) return result;

            result.AddRange(user.UserTeams.Select(x => x.TeamId).AsEnumerable());
            return result;

        }

        private List<Guid> GetProjects(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            List<Guid> result = new List<Guid>();

            if (user.UserProjects.IsNullOrEmpty()) return result;

            result.AddRange(user.UserProjects.Select(x => x.ProjectId).AsEnumerable());
            return result;
        }
    }
}