using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class DeleteUserCommand: Command, IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}