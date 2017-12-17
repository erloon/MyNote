namespace MyNote.Infrastructure.Model.Domain
{
    public abstract class BaseCommand : ICommand
    {
        public string Type
        {
            get { return this.GetType().Name; }
        }
    }
}