using System;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Address
{
    public class AddressCreated : DomainEvent
    {
        public Guid AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }

        public AddressCreated(CreateAddressCommand command, ITimeService timeService)
        {
            this.AddressId = Guid.NewGuid();
            this.Country = command.Country;
            this.City = command.City;
            this.Number = command.Number;
            this.Street = command.Street;
            this.CreateBy = command.CreateBy;
            this.UpdateBy = command.UpdateBy;
            this.Create = timeService.GetCurrent();
            this.Modification = timeService.GetCurrent();
        }
    }
}