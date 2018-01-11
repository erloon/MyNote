using System;
using System.Collections.Generic;

namespace MyNote.Notes.API.Model
{
    public class CreateNote
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public Guid? HeaderImage { get; set; }
        public List<Guid> Images { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? OrganizationId { get; set; }
        public List<Guid> Files { get; set; }

        public CreateNote()
        {
            
        }
    }
}