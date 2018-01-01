using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class RemoveUserFromTeamCommand : Command, IRequest<Model.User>
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid UpdateBy { get; set; }
    }
}