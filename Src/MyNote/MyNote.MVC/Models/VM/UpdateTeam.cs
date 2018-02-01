using System;

namespace MyNote.MVC.Models.VM
{
    public class UpdateTeam
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
    }
}