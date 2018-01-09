using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;
using MyNote.Notes.Domain.Commands;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Events
{
    public class FileCreated : DomainEvent
    {
        public Guid FileId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public decimal Size { get; set; }
        public byte[] Content { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }


        public FileCreated(CreateFileCommand command, ITimeService timeService)
        {
            this.FileId = Guid.NewGuid();
            this.OrganizationId = command.OrganizationId;
            this.Name = command.Name;
            this.FileType = command.FileType;
            this.Size = command.Size;
            this.Content = command.Content;
            this.Create = timeService.GetCurrent();
            this.Modification = timeService.GetCurrent();
            this.CreateBy = command.CreateBy;
            this.UpdateBy = command.UpdateBy;
        }
    }
}