using System;

namespace MyNote.MVC.Models.DTO
{
    public class ResourceUser
    {
        public Guid ResourceId { get; protected set; }
        public Guid UserId { get; protected set; }

        public ResourceUser()
        {

        }
    }
}