using System;

namespace MyNote.Notes.API.Model
{
    public class DeleteFile
    {
        public Guid FileId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}