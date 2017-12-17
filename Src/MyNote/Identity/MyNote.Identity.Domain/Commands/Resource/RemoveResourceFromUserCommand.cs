using System;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class RemoveResourceFromUserCommand
    {

        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid UserId { get; set; }
    }
}