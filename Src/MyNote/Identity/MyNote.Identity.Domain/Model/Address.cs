using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Events.Address;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class Address : BaseEntity
    {
        public Guid Id { get; protected set; }
        public string Country { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }

        public Address()
        {
        }
        public Address(CreateAddressCommand command,ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            var @event = new AddresCreated(command);

            Append(@event);
            Apply(@event, timeService);
        }

        public void Apply(AddresCreated @event, ITimeService timeService)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.Country = @event.Country;
            this.City = @event.City;
            this.Street = @event.Street;
            this.Number = @event.Number;
            this.Create = timeService.GetCurrent();
        }

        public void Update(UpdateAddressCommand command, ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            var @event = new AddressUpdated(command, timeService);

            Append(@event);
            Apply(@event);
        }

        public void Apply(AddressUpdated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.Country = @event.Country;
            this.City = @event.City;
            this.Street = @event.Street;
            this.Number = @event.Number;
            this.Modification = @event.Modyfication;
        }

        protected IEnumerable<object> GetAtomicValues()
        {
            yield return Country;
            yield return City;
            yield return Street;
            yield return Number;
        }
    }
}