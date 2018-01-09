using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Notes.Domain.Commands
{
    public class DeleteImageCommand : Command
    {
        public Guid ImageId { get; set; }
        public Guid OrganizationId { get; set; }

        public DeleteImageCommand()
        {
            
        }
    }
}