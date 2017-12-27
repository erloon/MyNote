using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Commands.Organization
{
    public class UpdateOrganizationCommand : Command, IRequest<Model.Organization>
    {
        public Guid OrganizationId { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime Modification { get; set; }
        public Guid UpdateBy { get; set; }

        public UpdateOrganizationCommand(Guid organizationId, Guid? addressId, Guid? companyId, string name, ITimeService timeService)
        {
            this.AddressId = addressId;
            this.CompanyId = companyId;
            this.Name = name;
            this.Modification = timeService.GetCurrent();
            this.OrganizationId = organizationId;
        }

    }
}