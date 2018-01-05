using System;
using MediatR;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class RemoveResourceFromUserCommand : IRequest<bool>
    {

        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}