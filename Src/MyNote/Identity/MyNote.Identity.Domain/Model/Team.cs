using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Team : BaseEntity
    {
        public string Name { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public Guid OwnerId { get; protected set; }
        public ApplicationUser User { get; protected set; }
        public virtual ICollection<UserTeam> UserTeams { get; protected set; }
        public virtual ICollection<ResourceTeam> ResourceTeams { get; protected set; }
    }
}