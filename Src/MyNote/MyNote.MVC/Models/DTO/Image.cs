using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.MVC.Models.DTO
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public Guid OrganizationId { get; set; }
        //public byte[] Content { get; set; }

        public Image()
        {

        }
        
    }
}