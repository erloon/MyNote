using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class AddUserToProjectCommand :Command, IRequest<Model.User>
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid UpdateBy { get; set; }
    }
}