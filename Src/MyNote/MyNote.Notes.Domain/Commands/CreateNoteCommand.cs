using System;
using System.Collections.Generic;
using MediatR;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Commands
{
    public class CreateNoteCommand : Command, IRequest<Note>
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public Guid HeaderImage { get; set; }
        public List<Guid> Images { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public Guid OwnerId { get; set; }
        public Guid OrganizationId { get; set; }
        public List<Guid> Files { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }

        public CreateNoteCommand()
        {

        }
    }
}