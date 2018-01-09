using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Notes.Domain.Commands
{
    public class CreateCategoryCommand : Command
    {
        public string Name { get; set; }
        public Guid OrganizationId { get; set; }

        public CreateCategoryCommand()
        {
            
        }
    }
}