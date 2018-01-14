using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.IntegrationEvents
{
    public class NoteUpdated : DomainEvent

    {
        public Guid NoteId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public Guid HeaderImage { get; set; }
        public List<Guid> Images { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public Guid OwnerId { get; set; }
        public Guid OrganizationId { get; set; }
        public List<Guid> Files { get; set; }
        public DateTime Modification { get; set; }
        public Guid UpdateBy { get; set; }

       
    }
}