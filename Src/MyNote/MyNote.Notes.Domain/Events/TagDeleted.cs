using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.Domain.Events
{
    public class TagDeleted : DomainEvent
    {
        public Guid TagId { get; set; }

        public TagDeleted(DeleteTagCommand command)
        {
            this.TagId = command.TagId;
        }
    }
}