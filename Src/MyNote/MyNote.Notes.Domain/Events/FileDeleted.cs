using System;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.Domain.Events
{
    public class FileDeleted
    {
        public Guid FileId { get; set; }

        public FileDeleted(DeleteFileCommand command)
        {
            this.FileId = command.FileId;
        }
    }
}