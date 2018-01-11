using MyNote.Notes.Domain.Model;
using MyNote.Notes.Infrastructure;

namespace MyNote.Notes.Domain.Repositories
{
    public interface IImageRepository : IDocumentRepository
    {
        void Add(Image image);
        void Delete(Image image);
    }
}