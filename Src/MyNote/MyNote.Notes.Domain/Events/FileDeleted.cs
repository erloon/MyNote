using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.Domain.Events
{
    public class FileDeleted : DomainEvent
    {
        public Guid FileId { get; set; }

        public FileDeleted(DeleteFileCommand command)
        {
            this.FileId = command.FileId;
        }
    }
}