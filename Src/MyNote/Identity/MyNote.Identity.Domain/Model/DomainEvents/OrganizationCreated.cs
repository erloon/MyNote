using System;
using MediatR;
using MyNote.Identity.Domain.Model.Commands;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model.DomainEvents
{
    public class OrganizationCreated : DomainEvent, INotification
    {
        public Organization Organization { get; set; }
        public CreateOrganizationCommand Command { get; set; }

        protected OrganizationCreated()
        {
        }

        public OrganizationCreated(Organization organization, CreateOrganizationCommand command, ITimeService timeService)
        {
            this.Organization = organization;
            this.Command = command;
            this.EntityName = typeof(Organization).Name;
            this.Create = timeService.GetCurrent();
            this.Id = Guid.NewGuid();
        }
    }
}