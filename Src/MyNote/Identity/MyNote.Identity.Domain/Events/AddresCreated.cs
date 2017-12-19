using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Address
{
    public class AddresCreated : IDomainEvent
    {
        public Guid AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}