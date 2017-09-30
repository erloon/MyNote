using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }

        public virtual ICollection<UserProjrct> UserProjects { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}