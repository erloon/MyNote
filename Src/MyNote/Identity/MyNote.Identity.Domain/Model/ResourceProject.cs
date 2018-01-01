using System;

namespace MyNote.Identity.Domain.Model
{
    public class ResourceProject
    {
        public Guid ResourceId { get; protected set; }
        public Guid ProjectId { get; protected set; }

        public ResourceProject(Guid ResourceId, Guid ProjectId)
        {
            this.ProjectId = ProjectId;
            this.ResourceId = ResourceId;
        }
    }
}