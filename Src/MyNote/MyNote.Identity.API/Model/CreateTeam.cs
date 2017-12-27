using System;

namespace MyNote.Identity.API.Model
{
    public class CreateTeam
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid OwnerId { get; set; }
    }
}