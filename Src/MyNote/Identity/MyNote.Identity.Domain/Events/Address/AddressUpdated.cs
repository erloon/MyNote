using System;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Address
{
    public class AddressUpdated : DomainEvent
    {
        public Guid AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public DateTime Modification { get; set; }
        public Guid UpdateBy { get; set; }

        public AddressUpdated(UpdateAddressCommand command, ITimeService timeService)
        {
            this.AddressId = command.AddressId;
            this.Country = command.Country;
            this.City = command.City;
            this.Number = command.Number;
            this.Street = command.Street;
            this.Modification = timeService.GetCurrent();
            this.UpdateBy = command.UpdateBy;
        }
    }
}