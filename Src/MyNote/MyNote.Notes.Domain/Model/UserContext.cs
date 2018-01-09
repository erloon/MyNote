using System;

namespace MyNote.Notes.Domain.Model
{
    public class UserContext
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}