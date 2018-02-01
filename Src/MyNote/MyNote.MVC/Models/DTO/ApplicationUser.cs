using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain.Commands.User;

namespace MyNote.MVC.Models.DTO
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }
        public ApplicationUser(RegisterUserCommand command)
        {
            this.UserName = command.Email;
            this.Email = command.Email;
        }
    }
}