using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Project
{
    public class DeleteProjectCommand : Command, IRequest<bool>
    {
        public Guid ProjectId { get; set; }
        public Guid OrganizationId { get; set; }

    }
}