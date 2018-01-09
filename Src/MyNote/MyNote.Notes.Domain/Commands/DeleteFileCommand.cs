using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Notes.Domain.Commands
{
    public class DeleteFileCommand : Command
    {
        public Guid FileId { get; set; }
        public Guid OrganizationId { get; set; }

        public DeleteFileCommand()
        {
            
        }
    }
}