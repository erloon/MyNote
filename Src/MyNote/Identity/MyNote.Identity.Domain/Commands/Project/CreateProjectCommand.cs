using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Project
{
    public class CreateProjectCommand : Command, IRequest<Model.Project>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid UpdateBy { get; set; }
        public Guid CreateBy { get; set; }
    }
}