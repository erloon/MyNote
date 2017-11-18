using System;

namespace MyNote.Identity.Domain.Model
{
    public class UserProject
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}