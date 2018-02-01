using System;

namespace MyNote.MVC.Models.DTO
{
    public class UserProject
    {
        public Guid UserId { get; protected set; }
        public Guid ProjectId { get; protected set; }

        public UserProject()
        {

        }

    }
}