using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.ApplicationUser
{
    public class RegisterNewUserCommand : BaseCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}