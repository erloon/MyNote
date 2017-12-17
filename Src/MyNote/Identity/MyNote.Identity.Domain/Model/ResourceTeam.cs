using System;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class ResourceTeam
    {
        public Resource Resource { get; protected set; }
        public Guid ResourceId { get; protected set; }
        public Team Team { get; protected set; }
        public Guid TeamId { get; protected set; }
    }
}