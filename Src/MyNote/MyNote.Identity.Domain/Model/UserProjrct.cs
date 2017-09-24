using System;

namespace MyNote.Identity.Domain.Model
{
    public class UserProjrct
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}