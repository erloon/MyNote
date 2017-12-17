using MyNote.Infrastructure.Model;

namespace MyNote.Identity.Domain.Model.Commands.User
{
    public class CreateUserCommand : ICommand
    {
        public string UserName { get; set; }
        public bool IsAdministrator { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}