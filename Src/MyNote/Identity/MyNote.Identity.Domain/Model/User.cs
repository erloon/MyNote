using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class User : BaseEntity
    {
        public ApplicationUser ApplicationUser { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public Organization Organization { get; protected set; }
        public bool IsAdministrator { get; protected set; }
        public bool IsConfirmByAdmin { get; protected set; }
        public virtual ICollection<UserTeam> UserTeams { get; protected set; }
        public virtual ICollection<UserProject> UserProjects { get; protected set; }
        public virtual ICollection<ResourceUser> ResourceUsers { get; protected set; }

        public User(ApplicationUser applicationUser,Organization organization)
        {
            this.Organization = organization;
            this.ApplicationUser = applicationUser;
        }
    }
}