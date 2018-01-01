using System;

namespace MyNote.Identity.API.Model
{
    public class DeleteUser
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}