using System;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Events.Company;
using MyNote.Infrastructure.Model.Domain;
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

        public Company()
        {
        }

        public void Update(UpdateCompanyCommand command, IDomainEventsService domainEventsService, ITimeService timeService)
        {
            var @event = new CompanyUpdated(command, timeService);
            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void Apply(CompanyCreated @event)
        {
            this.Name = @event.Name;
            this.VatNumber = @event.VatNumber;
            this.RegistrationNumber = @event.RegistrationNumber;
            this.Create = @event.Create;
            this.CreateBy = @event.CreateBy;
            this.Modification = @event.Modification;
            this.UpdateBy = @event.UpdateBy;
            this.OrganizationId = @event.OrganizationId;
            AddAddress(@event);
        }

        private void AddAddress(CompanyCreated @event)
        {
            Address address = new Address();
            @event.Address.UpdateBy = @event.UpdateBy;
            @event.Address.CreateBy = @event.CreateBy;
            @event.Address.OrganizationId = @event.OrganizationId;
            address.Apply(@event.Address);
            this.Address = address;
            this.AddressId = address.Id;
        }

        public void Apply(CompanyUpdated @event)
        {
            this.Name = @event.Name;
            this.VatNumber = @event.VatNumber;
            this.RegistrationNumber = @event.RegistrationNumber;
            this.OrganizationId = @event.OrganizationId;
            this.AddressId = @event.AddressId;
            this.Modification = @event.Modification;
            this.UpdateBy = @event.UpdateBy;
        }
    }
}