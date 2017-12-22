using System;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Organization
{
    public class OrganizationCreated : DomainEvent
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }

        public Guid? CreateBy { get; set; }
        public Guid? UpdateBy { get; set; }

        public OrganizationCreated(CreateOrganizationCommand command, ITimeService timeService)
        {
            this.OrganizationId = Guid.NewGuid();
            this.Name = command.Name;
            this.Create = timeService.GetCurrent();
            this.Modification = timeService.GetCurrent();
            this.CreateBy = command.CreateBy;
            this.UpdateBy = command.UpdateBy;
        }

    }
}