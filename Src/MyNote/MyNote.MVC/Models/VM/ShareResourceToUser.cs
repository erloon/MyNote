using System;

namespace MyNote.MVC.Models.VM
{
    public class ShareResourceToUser
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid UserId { get; set; }
    }
}