using System;
using MyNote.Infrastructure.Model;

namespace MyNote.Identity.Domain.Model.Commands
{
    public class CreateUserCommand : ICommand
    {
        public Guid OrganizationId { get; set; }
        public string UserName { get; set; }
        public bool IsAdministrator { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}