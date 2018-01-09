using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Notes.Domain.Model
{
    public class Note : Aggregate
    {
        public string Name { get; protected set; }
        public Category Category { get; protected set; }
        public string Title { get; protected set; }
        public string Subject { get; protected set; }
        public Image HeaderImage { get; protected set; }
        public virtual ICollection<Image> Images { get; protected set; }
        public string ShortDescription { get; protected set; }
        public string Content { get; protected set; }
        public int Version { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public bool IsFinal { get; protected set; }
        public Guid OwnerId { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public virtual ICollection<File> Files { get; protected set; }

        public Note()
        {
            
        }
    }
}