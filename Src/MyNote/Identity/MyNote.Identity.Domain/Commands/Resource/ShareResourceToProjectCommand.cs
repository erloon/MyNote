using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class ShareResourceToProjectCommand : Command, IRequest<bool>
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}