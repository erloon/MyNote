using System;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class CreateResourceCommand
    {
        public string UserId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}