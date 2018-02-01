using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Model;

namespace MyNote.MVC.Models.DTO
{
    public class Team
    {
        public string Name { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public Guid OwnerId { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public virtual ICollection<UserTeam> UserTeams { get; protected set; }
        public virtual ICollection<ResourceTeam> ResourceTeams { get; protected set; }

  
        public Team()
        {

        }
    }
}