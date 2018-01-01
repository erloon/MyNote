using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class UpdateUserCommand : Command, IRequest<Model.User>
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public Guid UpdateBy { get; set; }
    }
}