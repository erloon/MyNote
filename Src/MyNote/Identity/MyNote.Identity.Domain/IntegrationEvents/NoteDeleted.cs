using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.IntegrationEvents
{
    public class NoteDeleted : DomainEvent
    {
        public Guid NoteId { get; set; }

    }
}