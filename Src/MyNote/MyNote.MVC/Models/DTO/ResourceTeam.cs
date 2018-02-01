using System;

namespace MyNote.MVC.Models.DTO
{
    public class ResourceTeam
    {
        public Guid ResourceId { get; protected set; }
        public Guid TeamId { get; protected set; }

        public ResourceTeam()
        {
            
        }
        
    }
}