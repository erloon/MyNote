using System;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Events.Address;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Company
{
    public class CompanyCreated
    {
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public AddressCreated Address { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }


        public CompanyCreated(CreateCompanyCommand command, ITimeService timeService)
        {
            this.Name = command.Name;
            this.VatNumber = command.VatNumber;
            this.RegistrationNumber = command.RegistrationNumber;
            this.CreateBy = command.CreateBy;
            this.UpdateBy = command.UpdateBy;
            this.Address = new AddressCreated(command.Address, timeService);
            this.Create = timeService.GetCurrent();
            this.Modification = timeService.GetCurrent();
        }
    }
}