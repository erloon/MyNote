using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Company
{
    public class DeleteUserCommand : Command
    {
        public Guid Id { get; set; }
    }
}