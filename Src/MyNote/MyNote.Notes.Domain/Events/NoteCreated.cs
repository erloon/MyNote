﻿using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;
using MyNote.Notes.Domain.Commands;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Events
{
    public class NoteCreated : DomainEvent
    {
        public Guid NoteId { get; set; }
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
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }

        public NoteCreated(CreateNoteCommand command, ITimeService timeService)
        {
            this.Name = command.Name;
            this.CategoryId = command.CategoryId;
            this.Title = command.Title;
            this.ShortDescription = command.ShortDescription;
            this.Subject = command.Subject;
            this.HeaderImage = command.HeaderImage;
            this.Images = command.Images;
            this.Content = command.Content;
            this.OwnerId = command.OwnerId;
            this.OrganizationId = command.OrganizationId;
            this.Files = command.Files;
            this.Create = timeService.GetCurrent();
            this.Modification = timeService.GetCurrent();
            this.CreateBy = command.CreateBy;
            this.UpdateBy = command.UpdateBy;
        }

    }
}