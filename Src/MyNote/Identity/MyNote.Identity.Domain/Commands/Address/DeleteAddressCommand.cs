using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Address
{
    public class DeleteAddressCommand : Command
    {
        public Guid Id { get; set; }
    }
}