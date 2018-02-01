using System;

namespace MyNote.MVC.Models.VM
{
    public class CreateUser
    {
        public string UserName { get; set; }
        public bool IsAdministrator { get; set; }
        public Guid OrganizationId { get; set; }
    }
}