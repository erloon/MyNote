using MyNote.Infrastructure.Model.Database;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Repositories
{
    public interface IFileRepository : IDocumentRepository

    {
        void Add(File file);
        void Delete(File file);
    }
}