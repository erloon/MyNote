using System;
using System.Linq;
using Marten;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Queries
{
    public class ImageQuery : IImageQuery
    {
        private readonly IDocumentSession _documentSession;

        public ImageQuery(IDocumentSession documentSession)
        {
            if (documentSession == null) throw new ArgumentNullException(nameof(documentSession));
            _documentSession = documentSession;
        }
        public Image Get(Guid id)
        {
            return _documentSession.Query<Image>().FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}