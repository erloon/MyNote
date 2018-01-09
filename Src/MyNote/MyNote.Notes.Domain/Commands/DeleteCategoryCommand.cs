using System;

namespace MyNote.Notes.Domain.Commands
{
    public class DeleteCategoryCommand
    {
        public Guid CategoryId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}