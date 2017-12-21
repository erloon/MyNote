using System;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Events.Company;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class Company : BaseEntity
    {
        public string Name { get; protected set; }
        public Address Address { get; protected set; }
        public Guid AddressId { get; set; }
        public string VatNumber { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public Organization Organization { get; protected set; }

        protected Company()
        {
        }

        public Company(CreateCompanyCommand command, ITimeService timeService)
        {
            Apply(new CompanyCreated(command, timeService));
        }

        public void Update(UpdateCompanyCommand command)
        {
            Apply(new CompanyUpdated(command));
        }

        public void Apply(CompanyCreated @event)
        {
            this.Name = @event.Name;
            this.VatNumber = @event.VatNumber;
            this.RegistrationNumber = @event.RegistrationNumber;
            this.OrganizationId = @event.OrganizationId;
            this.AddressId = @event.AddressId;
        }

        public void Apply(CompanyUpdated @event)
        {
            this.Name = @event.Name;
            this.VatNumber = @event.VatNumber;
            this.RegistrationNumber = @event.RegistrationNumber;
            this.OrganizationId = @event.OrganizationId;
            this.AddressId = @event.AddressId;
        }
    }
}