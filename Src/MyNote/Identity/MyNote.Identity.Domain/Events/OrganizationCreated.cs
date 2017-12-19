using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events
{
    public class OrganizationCreated : IDomainEvent
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
    }
}