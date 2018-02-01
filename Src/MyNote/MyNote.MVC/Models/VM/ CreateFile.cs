using System;
using MyNote.MVC.Models.DTO;

namespace MyNote.MVC.Models.VM
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