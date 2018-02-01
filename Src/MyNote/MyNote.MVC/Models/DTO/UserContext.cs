using System;

namespace MyNote.MVC.Models.DTO
{
    public class UserContext
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}