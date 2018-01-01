using System;

namespace MyNote.Identity.API.Model
{
    public class RemoveUserFromProject
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }

    }
}