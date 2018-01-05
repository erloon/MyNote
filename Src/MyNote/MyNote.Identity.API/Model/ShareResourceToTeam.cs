using System;

namespace MyNote.Identity.API.Model
{
    public class ShareResourceToTeam
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid TeamId { get; set; }
    }
}