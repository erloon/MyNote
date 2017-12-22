using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Address
{
    public class UpdateAddressCommand : Command
    {
        public Guid AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public Guid UpdateBy { get; set; }
    }
}