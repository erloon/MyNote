using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.Domain.Events
{
    public class TagCreated : DomainEvent
    {
        public string Name { get; set; }

        public TagCreated(CreateTagCommand command)
        {
            this.Name = command.Name;
        }
    }
}