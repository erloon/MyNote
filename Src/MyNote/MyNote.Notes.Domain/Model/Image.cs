using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Notes.Domain.Model
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
    }
}