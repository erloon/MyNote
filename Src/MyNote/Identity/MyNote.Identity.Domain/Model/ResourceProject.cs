using System;

namespace MyNote.Identity.Domain.Model
{
    public class ResourceProject
    {
        public Resource Resource { get; protected set; }
        public Guid ResourceId { get; protected set; }
        public Project Project { get; protected set; }
        public Guid ProjectId { get; protected set; }
    }
}