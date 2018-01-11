using System;
using Marten;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IDocumentSession _documentSession;

        public FileRepository(IDocumentSession documentSession)
        {
            if (documentSession == null) throw new ArgumentNullException(nameof(documentSession));
            _documentSession = documentSession;
        }
        public void Save()
        {
            _documentSession.SaveChanges();
        }

        public void Add(File file)
        {
            _documentSession.Insert(file);
        }

        public void Delete(File file)
        {
            _documentSession.Delete(file);
        }
    }
}