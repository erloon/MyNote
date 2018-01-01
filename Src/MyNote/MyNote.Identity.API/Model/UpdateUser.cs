using System;

namespace MyNote.Identity.API.Model
{
    public class UpdateUser
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
    }
}