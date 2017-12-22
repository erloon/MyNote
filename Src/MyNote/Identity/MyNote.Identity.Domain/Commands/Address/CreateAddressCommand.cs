using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Address
{
    public class CreateAddressCommand : Command, IRequest<Model.Organization>
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public Guid OrganizationId { get; set; }

        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }

        public CreateAddressCommand(string country, string city, string street, string number, Guid organizationId)
        {
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.Number = number;
            this.OrganizationId = organizationId;
        }
    }
}