using System;

namespace MyNote.Identity.API.Model
{
    public class AddUserToProject
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}