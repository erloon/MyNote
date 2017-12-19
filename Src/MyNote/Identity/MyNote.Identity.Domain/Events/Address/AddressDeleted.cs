using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Address
{
    public class AddressDeleted : DomainEvent
    {
        public AddressDeleted(Guid addressId)
        {
        }

        public Guid AddressId { get; set; }
    }
}