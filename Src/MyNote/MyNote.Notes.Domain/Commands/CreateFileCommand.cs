using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Commands
{
    public class CreateFileCommand : Command
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public decimal Size { get; set; }
        public byte[] Content { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }


        public CreateFileCommand()
        {
            
        }
    }
}