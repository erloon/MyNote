using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Team :BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid OwnerId { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<UserTeam> UserTeams { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}