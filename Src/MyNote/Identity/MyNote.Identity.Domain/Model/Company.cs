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

        public Company(CreateCompanyCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new CompanyCreated(command, timeService);
            Save(@event, domainEventsService);
            Apply(@event);

        }

        public void Update(UpdateCompanyCommand command, IDomainEventsService domainEventsService, ITimeService timeService)
        {
            var @event = new CompanyUpdated(command, timeService);
            Save(@event, domainEventsService);
            Apply(@event);
        }

        public void Apply(CompanyCreated @event)
        {
            this.Name = @event.Name;
            this.VatNumber = @event.VatNumber;
            this.RegistrationNumber = @event.RegistrationNumber;
            this.OrganizationId = @event.OrganizationId;
            this.AddressId = @event.AddressId;
            this.Create = @event.Create;
            this.CreateBy = @event.CreateBy;
            this.Modification = @event.Modification;
            this.UpdateBy = @event.UpdateBy;
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