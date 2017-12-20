using System;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Company
{
    public class CompanyCreated : DomainEvent
    {
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public Guid AddressId { get; set; }
        public Guid OrganizationId { get; set; }
        public DateTime Create { get; set; }

        public CompanyCreated(CreateCompanyCommand command, ITimeService timeService)
        {
            Name = command.Name;
            VatNumber = command.VatNumber;
            RegistrationNumber = command.RegistrationNumber;
            AddressId = command.AddressId;
            OrganizationId = command.OrganizationId;
            Create = timeService.GetCurrent();
        }
    }
}