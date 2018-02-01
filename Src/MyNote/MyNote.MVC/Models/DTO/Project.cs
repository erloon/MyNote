using System;
using System.Collections.Generic;

namespace MyNote.MVC.Models.DTO
{
    public class Project
    {
        public string Name { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public string Subject { get; protected set; }
        public string Description { get; protected set; }
        public Guid OrganizationId { get; protected set; }

        public virtual ICollection<UserProject> UserProjects { get; protected set; }
        public virtual ICollection<ResourceProject> ResourceProjects { get; protected set; }

        public Project()
        {
        }
    }
}