using System;

namespace MyNote.MVC.Models.VM
{
    public class DeleteImage
    {
        public Guid ImageId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}