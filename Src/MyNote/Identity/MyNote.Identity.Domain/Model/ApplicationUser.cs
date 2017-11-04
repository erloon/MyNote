using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyNote.Identity.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsConfirmByAdmin { get; set; }
        public virtual ICollection<UserTeam> UserTeams { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }

    }
}