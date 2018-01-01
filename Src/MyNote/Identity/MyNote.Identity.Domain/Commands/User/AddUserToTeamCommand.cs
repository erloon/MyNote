using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class AddUserToTeamCommand : Command, IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
        public Guid UpdateBy { get; set; }
    }
}