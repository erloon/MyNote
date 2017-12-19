using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Project : BaseEntity
    {
        public string Name { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public string Subject { get; protected set; }
        public string Description { get; protected set; }
        public Organization Organization { get; protected set; }
        public Guid OrganizationId { get; protected set; }

        public virtual ICollection<UserProject> UserProjects { get; protected set; }
        public virtual ICollection<ResourceProject> ResourceProjects { get; protected set; }

        public Project()
        {
        }

        public Project(CreateProjectCommand command)
        {
            
        }
    }
}