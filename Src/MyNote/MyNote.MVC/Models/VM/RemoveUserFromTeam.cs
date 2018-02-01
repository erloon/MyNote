using System;

namespace MyNote.MVC.Models.VM
{
    public class RemoveUserFromTeam
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
    }
}