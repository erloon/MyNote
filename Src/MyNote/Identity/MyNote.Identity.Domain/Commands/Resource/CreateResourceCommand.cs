using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class CreateResourceCommand : Command, IRequest<Model.Organization>
    {
        public string OwnerId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid? ContentId { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
    }
}