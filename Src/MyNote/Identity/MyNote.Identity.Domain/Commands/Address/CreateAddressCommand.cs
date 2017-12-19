using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Address
{
    public class CreateAddressCommand : Command
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public Guid OrganizationId { get; set; }

        public CreateAddressCommand(string country, string city, string street, string number, Guid organizationId)
        {
            this.Country = country;
            this.City = City;
            this.Street = street;
            this.Number = number;
            this.OrganizationId = organizationId;
        }
    }
}