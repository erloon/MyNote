using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class RemoveUserFromProjectCommand : Command
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}