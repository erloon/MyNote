using MyNote.Notes.Domain.Model;
using IDocumentRepository = MyNote.Notes.Infrastructure.IDocumentRepository;

namespace MyNote.Notes.Domain.Repositories
{
    public interface INoteRepository : IDocumentRepository
    {
        void Add(Note note);
        void Delete(Note note);
        void Update(Note note);
    }
}