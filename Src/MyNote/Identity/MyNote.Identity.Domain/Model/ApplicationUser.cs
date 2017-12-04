using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain.Model.Commands.User;

namespace MyNote.Identity.Domain.Model
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