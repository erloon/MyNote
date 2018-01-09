using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.Domain.Events
{
    public class NoteDeleted : DomainEvent
    {
        public Guid NoteId { get; set; }

        public NoteDeleted(DeleteNoteCommand command)
        {
            this.NoteId = command.NoteId;
        }
    }
}