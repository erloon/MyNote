using System;
using MyNote.Identity.Domain.Model.Commands;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public Address Address { get; private set; }
        public string VatNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

        protected Company()
        {

        }
        public Company(CreateCompanyCommand command, Address address, Guid organizationId)
        {
            this.Name = command.Name;
            this.VatNumber = command.VatNumber;
            this.RegistrationNumber = command.RegistrationNumber;
            this.OrganizationId = organizationId;
            this.Address = address;
        }

    }
}