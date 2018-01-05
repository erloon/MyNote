using System;

namespace MyNote.Identity.API.Model
{
    public class ShareResourceToProject
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid ProjectId { get; set; }
    }
}