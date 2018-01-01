using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Team
{
    public class DeleteTeamCommand : Command, IRequest<bool>
    {
        public Guid TeamId { get; set; }
        public Guid OrganizationId { get; set; }

        public Guid UpdateBy { get; set; }
    }
}