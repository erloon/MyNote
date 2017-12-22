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
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }


        public CompanyCreated(CreateCompanyCommand command, ITimeService timeService)
        {
            this.Name = command.Name;
            this.VatNumber = command.VatNumber;
            this.RegistrationNumber = command.RegistrationNumber;
            this.AddressId = command.AddressId;
            this.OrganizationId = command.OrganizationId;
            this.CreateBy = command.CreateBy;
            this.UpdateBy = command.UpdateBy;
            this.Create = timeService.GetCurrent();
            this.Modification = timeService.GetCurrent();
        }
    }
}