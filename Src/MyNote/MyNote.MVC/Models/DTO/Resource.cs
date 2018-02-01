using System;
using System.Collections.Generic;
using System.Linq;

namespace MyNote.MVC.Models.DTO
{
    public class Resource 
    {
        public string OwnerId { get; protected set; }
        public User Owner { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public Guid? ContentId { get; protected set; }

        public virtual ICollection<ResourceUser> ResourceUsers { get; protected set; }
        public virtual ICollection<ResourceProject> ResourceProjects { get; protected set; }
        public virtual ICollection<ResourceTeam> ResourceTeams { get; protected set; }


        public Resource()
        {
        }
    }
}