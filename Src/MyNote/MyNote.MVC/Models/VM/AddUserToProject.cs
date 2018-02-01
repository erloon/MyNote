using System;

namespace MyNote.MVC.Models.VM
{
    public class AddUserToProject
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}