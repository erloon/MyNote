using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Notes.Domain.Commands
{
    public class CreateTagCommand : Command
    {
        public string Name { get; set; }

        public CreateTagCommand()
        {
            
        }
    }
    
}