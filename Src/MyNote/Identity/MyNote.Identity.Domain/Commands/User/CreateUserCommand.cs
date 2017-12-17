using System;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class CreateUserCommand : BaseCommand
    {
        public string UserName { get; set; }
        public bool IsAdministrator { get; set; }
        public Guid AppliCationUserId { get; set; }
    }
}