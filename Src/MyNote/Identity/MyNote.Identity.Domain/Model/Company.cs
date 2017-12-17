using System;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Company : BaseEntity
    {
        public string Name { get; protected set; }
        public Address Address { get; private set; }
        public string VatNumber { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public Organization Organization { get; protected set; }

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