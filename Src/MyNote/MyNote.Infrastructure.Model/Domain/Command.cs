using System;

namespace MyNote.Infrastructure.Model.Domain
{
    public class Command : ICommand
    {
        public Command()
        {
            this.Id = Guid.NewGuid();
            this.CreateDate = DateTime.Now;
        }
        public Guid Id { get; }
        public DateTime CreateDate { get;}
    }
}