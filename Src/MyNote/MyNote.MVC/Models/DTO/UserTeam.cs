using System;

namespace MyNote.MVC.Models.DTO
{
    public class UserTeam 
    {
        public Guid TeamId { get; protected set; }
       
        public Guid UserId { get; protected set; }

        public UserTeam()
        {

        }
    }
    
}