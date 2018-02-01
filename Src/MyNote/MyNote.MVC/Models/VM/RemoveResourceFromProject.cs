using System;

namespace MyNote.MVC.Models.VM
{
    public class RemoveResourceFromProject
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid ProjectId { get; set; }
    }
}