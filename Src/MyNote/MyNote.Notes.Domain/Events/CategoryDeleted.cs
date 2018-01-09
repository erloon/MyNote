using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.Domain.Events
{
    public class CategoryDeleted : DomainEvent
    {
        public Guid CategoryId { get; set; }

        public CategoryDeleted(DeleteCategoryCommand command)
        {
            this.CategoryId = command.CategoryId;
        }
    }
}