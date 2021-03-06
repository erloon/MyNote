﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Infrastructure.Services
{
    public class OrganizationContextService : IOrganizationContextService
    {
        private readonly IUserQuery _userQuery;
        private readonly IOrganizationQuery _organizationQuery;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITeamQuery _teamQuery;
        private readonly IProjectQuery _projectQuery;

        public OrganizationContextService(IUserQuery userQuery,
                                          IOrganizationQuery organizationQuery,
                                          UserManager<ApplicationUser> userManager,
                                          ITeamQuery teamQuery,
                                          IProjectQuery projectQuery)
        {
            if (userQuery == null) throw new ArgumentNullException(nameof(userQuery));
            if (organizationQuery == null) throw new ArgumentNullException(nameof(organizationQuery));
            if (userManager == null) throw new ArgumentNullException(nameof(userManager));

            _userQuery = userQuery;
            _organizationQuery = organizationQuery;
            _userManager = userManager;
            _teamQuery = teamQuery ?? throw new ArgumentNullException(nameof(teamQuery));
            _projectQuery = projectQuery ?? throw new ArgumentNullException(nameof(projectQuery));
        }
        public async Task<OrganizationContext> Get(string userName)
        {
            var user = _userQuery.Get(userName);
            var applicationUser = _userManager.Users.FirstOrDefault(x => x.Email.Equals(userName));
            var context = new OrganizationContext()
            {
                UserId = user.Id,
                OrganizationId = user.OrganizationId,
                ProjectsOwnership = GetProjects(user),
                TeamsOwnership = GetTeams(user),
                ApplicationUser = applicationUser,
                AvailableProjects = GetAvailableProjects(user),
                AvaliableTeams = GetAvailableTeams(user)

            };
            return context;
        }

        private List<AvailableTeam> GetAvailableTeams(User user)
        {
            var teams = _teamQuery.GetAllAsync(user.OrganizationId).Result.Items.Select(x => new { x.Name, x.Id }).ToList();
            List<AvailableTeam> availableTeams = new List<AvailableTeam>();
            teams.ForEach(x=>availableTeams.Add(new AvailableTeam()
            {
                Id = x.Id,
                Name = x.Name
            }));
            return availableTeams;
        }

        private List<AvailableProject> GetAvailableProjects(User user)
        {
            var projects = _projectQuery.GetAllAsync(user.OrganizationId).Result.Items.Select(x => new { x.Name, x.Id }).ToList();
            List<AvailableProject> availableProjects = new List<AvailableProject>();
            projects.ForEach(x => availableProjects.Add(new AvailableProject()
            {
                Id = x.Id,
                Name = x.Name
            }));

            return availableProjects;
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