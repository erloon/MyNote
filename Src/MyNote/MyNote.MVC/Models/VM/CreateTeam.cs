using System;

namespace MyNote.MVC.Models.VM
{
    public class CreateTeam
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid OwnerId { get; set; }
    }
}