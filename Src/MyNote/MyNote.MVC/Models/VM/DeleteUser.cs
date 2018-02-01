using System;

namespace MyNote.MVC.Models.VM
{
    public class DeleteUser
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}