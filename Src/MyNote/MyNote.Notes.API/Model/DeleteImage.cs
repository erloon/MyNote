using System;

namespace MyNote.Notes.API.Model
{
    public class DeleteImage
    {
        public Guid ImageId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}