using System;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Company
{
    public class CompanyUpdated : DomainEvent

    {
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public Guid AddressId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime Modification { get; set; }

        public CompanyUpdated(UpdateCompanyCommand command, ITimeService timeService)
        {
            this.Name = command.Name;
            this.VatNumber = command.VatNumber;
            this.RegistrationNumber = command.RegistrationNumber;
            this.OrganizationId = command.OrganizationId;
            this.AddressId = command.AddressId;
            this.Modification = timeService.GetCurrent();
            this.UpdateBy = command.UpdateBy;
        }
    }
}