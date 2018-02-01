using System;

namespace MyNote.MVC.Models.DTO
{
    public class ResourceProject
    {
        public Guid ResourceId { get; protected set; }
        public Guid ProjectId { get; protected set; }

        public ResourceProject()
        {
            
        }
     
    }
}