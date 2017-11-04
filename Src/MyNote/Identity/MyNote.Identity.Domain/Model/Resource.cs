using System;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Resource : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public Guid? ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid? TeamId { get; set; }
        public Team Team { get; set; }
        public Guid? ContentId { get; set; }
    }
}