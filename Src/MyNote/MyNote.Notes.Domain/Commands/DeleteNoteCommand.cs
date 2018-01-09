using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Notes.Domain.Commands
{
    public class DeleteNoteCommand : Command, IRequest<bool>
    {
        public Guid NoteId { get; set; }
        public Guid OrganizationId { get; set; }

        public DeleteNoteCommand()
        {
            
        }
    }
}