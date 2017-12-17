namespace MyNote.Infrastructure.Model.Domain
{
    public interface ICommand
    {
        string Type { get; }
    }
}