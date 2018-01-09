using System;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Notes.Domain.Commands
{
    public class UpdateCategoryCommand : Command
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime Modification { get; set; }

        public UpdateCategoryCommand(UpdateCategoryCommand command, ITimeService timeService)
        {
            this.CategoryId = command.CategoryId;
            this.Modification = timeService.GetCurrent();
            this.UpdateBy = command.UpdateBy;
            this.Name = command.Name;
        }
    }
}