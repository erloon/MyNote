using System;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.API.Model
{
    public class  CreateFile
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public decimal Size { get; set; }
        public byte[] Content { get; set; }
    }
}