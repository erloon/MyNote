using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Model.Commands;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Address : ValueObject
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

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