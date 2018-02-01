using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.MVC.Models.DTO
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public Category Category { get;  set; }
        public string Title { get;  set; }
        public string Subject { get;  set; }
        public Image HeaderImage { get;  set; }
        public virtual List<Guid> Images { get;  set; }
        public string ShortDescription { get;  set; }
        public string Content { get;  set; }
        public int Version { get;  set; }
        public bool IsDeleted { get;  set; }
        public bool IsFinal { get;  set; }
        public Guid OwnerId { get;  set; }
        public Guid OrganizationId { get;  set; }
        public virtual List<Guid> Files { get;  set; }

        public Note()
        {

        }

    }
}