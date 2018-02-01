using System;

namespace MyNote.MVC.Models.VM
{
    public class UpdateUser
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
    }
}