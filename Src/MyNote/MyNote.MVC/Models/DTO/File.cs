using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.MVC.Models.DTO
{
    public enum FileType
    {
        PDF,
        TXT
    }
    public class File
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public decimal Size { get; set; }
        public string Path { get; set; }
        //public byte[] Content { get; set; }
        public Guid OrganizationId { get; set; }

        public File()
        {

        }

    }
}