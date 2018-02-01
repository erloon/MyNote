using System;

namespace MyNote.MVC.Models.VM
{
    public class RemoveUserFromProject
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }

    }
}