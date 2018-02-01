using System;
using Microsoft.AspNetCore.Http;

namespace MyNote.MVC.Models.VM
{
    public class CreateImage
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid OrganizationId { get; set; }
        public byte[] Content { get; set; }
        public CreateImage()
        {
            
        }
    }
}