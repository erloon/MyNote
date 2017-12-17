using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Resource : BaseEntity
    {
        public string OwnerId { get;protected set; }
        public User Owner { get;protected set; }
        public Guid OrganizationId { get;protected set; }
        public Organization Organization { get; protected set; }
        public Guid? ContentId { get; protected set; }

        public virtual ICollection<ResourceUser> ResourceUsers { get; protected set; }
        public virtual ICollection<ResourceProject> ResourceProjects { get; protected set; }
        public virtual ICollection<ResourceTeam> ResourceTeams { get; protected set; }
    }
}