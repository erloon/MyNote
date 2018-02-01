using System;

namespace MyNote.MVC.Models.VM
{
    public class AddUserToTeam
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}