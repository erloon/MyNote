using System;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class ResourceTeam
    {
        public Guid ResourceId { get; protected set; }
        public Guid TeamId { get; protected set; }

        public ResourceTeam(Guid resourceId, Guid teamId)
        {
            this.ResourceId = resourceId;
            this.TeamId = teamId;
        }
    }
}