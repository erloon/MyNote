using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.Domain.Events
{
    public class CategoryUpdated : DomainEvent

    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public CategoryUpdated(UpdateCategoryCommand command)
        {
            this.CategoryId = command.CategoryId;
            this.Name = command.Name;
        }
    }
}