using System;
using System.Collections.Generic;
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

        private Address()
        {
        }
        public Address(string country, string city, string street, string number)
        {
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.Number = number;
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