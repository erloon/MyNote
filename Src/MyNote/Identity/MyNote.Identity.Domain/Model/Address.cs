using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Address : ValueObject
    {
        public Guid Id { get; protected set; }
        public string Country { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }

        public Address()
        {
        }
        public Address(CreateAddressCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            this.Country = command.Country;
            this.City = command.City;
            this.Street = command.Street;
            this.Number = command.Number;
        }

        public void Update(UpdateAddressCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            this.Country = command.Country;
            this.City = command.City;
            this.Street = command.Street;
            this.Number = command.Number;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Country;
            yield return City;
            yield return Street;
            yield return Number;
        }
    }
}