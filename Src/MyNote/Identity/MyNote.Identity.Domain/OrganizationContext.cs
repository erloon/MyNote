using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain
{
    public class OrganizationContext
    {
        public Guid OrganizationId { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> TeamsOwnership { get; set; }
        public List<Guid> ProjectsOwnership { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<AvailableTeam> AvaliableTeams { get; set; }
        public List<AvailableProject> AvailableProjects { get; set; }
    }
}