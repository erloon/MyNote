using System;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Organization
{
    public class OrganizationCreated : DomainEvent
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }

        public OrganizationCreated(CreateOrganizationCommand command)
        {
            OrganizationId = Guid.NewGuid();
            Name = command.Name;
        }

    }
}