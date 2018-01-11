using System;
using System.Collections.Generic;
using System.Linq;
using Marten;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Queries
{
    public class NotesQuery : INotesQuery
    {
        private readonly IDocumentSession _documentSession;

        public NotesQuery(IDocumentSession documentSession)
        {
            if (documentSession == null) throw new ArgumentNullException(nameof(documentSession));
            _documentSession = documentSession;
        }
        public Note Get(Guid id)
        {
            var ses = _documentSession.DocumentStore.QuerySession();
            var i = ses.Query<Note>().FirstOrDefault(x => x.Id.Equals(id));
            var e = ses.Load<Note>(id);
            return i;
        }

        public List<Note> Get(List<Guid> noteIds)
        {
            return _documentSession.Query<Note>()
                .Where(x => noteIds.Contains(x.Id))
                .ToList();
        }
        
    }
}