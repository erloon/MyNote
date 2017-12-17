using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Address
{
    public class DeleteAddressCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }
}