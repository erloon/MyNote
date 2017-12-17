namespace MyNote.Infrastructure.Model
{
    public interface ICommand
    {
        string Type { get; set; }
    }
}