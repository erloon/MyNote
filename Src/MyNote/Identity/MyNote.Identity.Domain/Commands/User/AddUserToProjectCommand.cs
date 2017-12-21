using System;

namespace MyNote.Identity.Domain.Commands.User
{
    public class AddUserToProjectCommand
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}