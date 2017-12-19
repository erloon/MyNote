using System;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Address
{
    public class AddressUpdated : DomainEvent
    {
        public Guid AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public AddressUpdated(UpdateAddressCommand command)
        {
            this.AddressId = command.AddressId;
            this.Country = command.Country;
            this.City = command.City;
            this.Street = command.Street;
            this.Number = command.Number;
        }
    }
}