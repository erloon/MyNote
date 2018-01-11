using System;
using System.Linq;
using Marten;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Queries
{
    public class FIleQuery : IFIleQuery
    {
        private readonly IDocumentSession _documentSession;

        public FIleQuery(IDocumentSession documentSession)
        {
            if (documentSession == null) throw new ArgumentNullException(nameof(documentSession));
            _documentSession = documentSession;
        }
        public File Get(Guid id)
        {
            var result = _documentSession.Query<File>().FirstOrDefault(x => x.Id.Equals(id));
            return result;
        }
    }
}