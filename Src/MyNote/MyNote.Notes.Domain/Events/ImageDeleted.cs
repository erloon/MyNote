using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.Domain.Events
{
    public class ImageDeleted : DomainEvent

    {
        public Guid ImageId { get; set; }

        public ImageDeleted(DeleteImageCommand command)
        {
            this.ImageId = command.ImageId;
        }
    }
}