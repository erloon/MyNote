using System;

namespace MyNote.Identity.Domain.Model
{
    public class ResourceUser
    {
        public Guid ResourceId { get; protected set; }
        public Guid UserId { get; protected set; }

        public ResourceUser()
        {
            
        }

        public ResourceUser(Guid resourceId, Guid userId)
        {
            this.ResourceId = resourceId;
            this.UserId = userId;
        }
    }
}