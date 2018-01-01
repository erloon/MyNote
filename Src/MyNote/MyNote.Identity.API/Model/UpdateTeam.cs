using System;
using System.Reflection.Metadata.Ecma335;

namespace MyNote.Identity.API.Model
{
    public class UpdateTeam
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
    }
}