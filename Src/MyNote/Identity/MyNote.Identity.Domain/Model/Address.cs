using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Events.Address;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class Address : BaseEntity
    {
        public string Country { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }

        public Address()
        {
        }
        //public Address(CreateAddressCommand command,ITimeService timeService, IDomainEventsService domainEventsService)
        //{
        //    if (command == null) throw new ArgumentNullException(nameof(command));
        //    var @event = new AddressCreated(command, timeService);

        //    Save(@event);
        //    domainEventsService.Save(@event);
        //    Apply(@event);
        //}

        public void Apply(AddressCreated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.Id = @event.AddressId;
            this.Country = @event.Country;
            this.City = @event.City;
            this.Street = @event.Street;
            this.Number = @event.Number;
            this.Create = @event.Create;
            this.Modification = @event.Modification;
            this.CreateBy = @event.CreateBy;
            this.UpdateBy = @event.UpdateBy;
        }

        public void Update(UpdateAddressCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            var @event = new AddressUpdated(command, timeService);

            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void Apply(AddressUpdated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.Country = @event.Country;
            this.City = @event.City;
            this.Street = @event.Street;
            this.Number = @event.Number;
            this.Modification = @event.Modification;
            this.UpdateBy = @event.UpdateBy;
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