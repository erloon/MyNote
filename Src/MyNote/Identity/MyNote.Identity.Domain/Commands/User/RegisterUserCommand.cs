using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.User
{
    public class RegisterUserCommand : Command, IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}