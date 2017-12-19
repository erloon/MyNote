using System;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Address
{
    public class AddresCreated : DomainEvent
    {
        public Guid AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public AddresCreated(CreateAddressCommand command)
        {
            this.AddressId = Guid.NewGuid();
            this.Country = command.Country;
            this.City = command.City;
            this.Number = command.Number;
            this.Street = command.Street;
        }
    }
}