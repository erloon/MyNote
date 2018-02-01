using System;
using System.Collections.Generic;
using System.Linq;
using MyNote.Identity.Domain.Model;

namespace MyNote.MVC.Models.DTO
{
    public class User
    {
        public Guid OrganizationId { get; protected set; }
        public bool IsAdministrator { get; protected set; }
        public bool IsConfirmByAdmin { get; protected set; }
        public virtual ICollection<UserTeam> UserTeams { get; protected set; }
        public virtual ICollection<UserProject> UserProjects { get; protected set; }
        public virtual ICollection<ResourceUser> ResourceUsers { get; protected set; }

        public User()
        {

        }
    }
}