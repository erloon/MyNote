using System;

namespace MyNote.Identity.API.Model
{
    public class UpdateProject
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }
    }
}