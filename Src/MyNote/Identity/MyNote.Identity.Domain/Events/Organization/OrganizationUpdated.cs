using System;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Organization
{
    public class OrganizationUpdated : DomainEvent
    {
        public Guid OrganizationId { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime Modification { get; set; }
        public Guid? UpdateBy { get; set; }


        public OrganizationUpdated(UpdateOrganizationCommand command)
        {
            this.OrganizationId = command.OrganizationId;
            this.AddressId = command.AddressId;
            this.CompanyId = command.CompanyId;
            this.Name = command.Name;
            this.Modification = command.Modification;
            this.UpdateBy = command.UpdateBy;
        }
    }
}