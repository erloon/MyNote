using System;

namespace MyNote.MVC.Models.VM
{
    public class DeleteFile
    {
        public Guid FileId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}