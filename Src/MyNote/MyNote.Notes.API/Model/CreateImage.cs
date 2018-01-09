using System;

namespace MyNote.Notes.API.Model
{
    public class CreateImage
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid OrganizationId { get; set; }
        public byte[] Content { get; set; }

    }
}