using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Model.Commands.User;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class User : BaseEntity
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsConfirmByAdmin { get; set; }
        public virtual ICollection<UserTeam> UserTeams { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }

        public User(ApplicationUser applicationUser,Organization organization)
        {
            this.Organization = organization;
            this.ApplicationUser = applicationUser;
        }
    }
}