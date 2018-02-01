using System;

namespace MyNote.MVC.Models.VM
{
    public class RemoveResourceFromTeam
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid TeamId { get; set; }
    }
}