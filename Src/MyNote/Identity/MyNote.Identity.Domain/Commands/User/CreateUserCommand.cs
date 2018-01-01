using System;
using MediatR;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class CreateUserCommand : Command, IRequest<Model.User>
    {
        public string UserName { get; set; }
        public bool IsAdministrator { get; set; }
        public Model.ApplicationUser ApplicationUser { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
    }
}