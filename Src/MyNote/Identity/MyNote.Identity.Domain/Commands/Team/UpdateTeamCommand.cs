using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Team
{
    public class UpdateTeamCommand : Command, IRequest<Model.Team>
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public Guid OrganizationId { get; set; }
        public DateTime Modification { get; set; }
        public Guid UpdateBy { get; set; }


    }
}