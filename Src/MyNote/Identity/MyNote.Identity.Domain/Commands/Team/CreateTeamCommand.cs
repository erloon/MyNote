using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Team
{
    public class CreateTeamCommand : Command, IRequest<Model.Team>
    {
        public string Name { get; set; }
         public Guid OrganizationId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? CreateBy { get; set; }
        public Guid? UpdateBy { get; set; }
    }
}