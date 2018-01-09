using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.Domain.Events
{
    public class CategoryCreated : DomainEvent
    {

        public string Name { get; set; }
        public Guid CategoryId { get; set; }

        public CategoryCreated(CreateCategoryCommand command)
        {
            this.Name = command.Name;
            this.CategoryId = Guid.NewGuid();
        }
    }
}