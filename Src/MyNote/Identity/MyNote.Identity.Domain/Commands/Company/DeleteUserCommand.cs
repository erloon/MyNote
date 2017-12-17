using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Company
{
    public class DeleteUserCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }
}