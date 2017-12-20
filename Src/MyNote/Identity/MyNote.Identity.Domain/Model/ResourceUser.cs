using System;

namespace MyNote.Identity.Domain.Model
{
    public class ResourceUser
    {
        public Resource Resource { get; protected set; }
        public Guid ResourceId { get; protected set; }
        public User User { get; protected set; }
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