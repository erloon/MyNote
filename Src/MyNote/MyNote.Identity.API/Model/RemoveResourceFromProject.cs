using System;

namespace MyNote.Identity.API.Model
{
    public class RemoveResourceFromProject
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid ProjectId { get; set; }
    }
}