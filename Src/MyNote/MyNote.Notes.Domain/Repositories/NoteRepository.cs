using System;
using Marten;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly IDocumentSession _documentSession;

        public NoteRepository(IDocumentSession documentSession)
        {
            if (documentSession == null) throw new ArgumentNullException(nameof(documentSession));
            _documentSession = documentSession;
        }
        public void Save()
        {
            _documentSession.SaveChanges();
        }

        public void Add(Note note)
        {
            _documentSession.Insert(note);
        }

        public void Delete(Note note)
        {
            _documentSession.Delete(note);
        }

        public void Update(Note note)
        {
            _documentSession.Update(note);
        }
    }
}