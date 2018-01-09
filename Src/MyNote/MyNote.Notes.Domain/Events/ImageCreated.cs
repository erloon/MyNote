using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.Domain.Events
{
    public class ImageCreated : DomainEvent
    {
        public Guid ImageId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid OrganizationId { get; set; }
        public byte[] Content { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }

        public ImageCreated(CreateImageCommand command, ITimeService timeService)
        {
            this.ImageId = Guid.NewGuid();
            this.Name = command.Name;
            this.Type = command.Type;
            this.OrganizationId = command.OrganizationId;
            this.Content = command.Content;
            this.Create = timeService.GetCurrent();
            this.Modification = timeService.GetCurrent();
        }
    }
}