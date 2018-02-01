using System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class RegisterUserCommand : Command, IRequest<IdentityResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}