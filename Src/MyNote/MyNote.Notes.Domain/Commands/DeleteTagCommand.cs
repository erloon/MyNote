using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Notes.Domain.Commands
{
    public class DeleteTagCommand : Command
    {
        public Guid TagId { get; set; }

        public DeleteTagCommand()
        {
            
        }
    }
}