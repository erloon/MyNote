using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Notes.Domain.Model
{
    public enum FileType
    {
        PDF,
        TXT
    }
    public class File : BaseEntity
    {
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public decimal Size { get; set; }
        public string Path { get; set; }
    }
}