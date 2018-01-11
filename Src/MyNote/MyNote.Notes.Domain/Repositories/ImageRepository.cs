using System;
using Marten;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IDocumentSession _documentSession;

        public ImageRepository(IDocumentSession documentSession)
        {
            if (documentSession == null) throw new ArgumentNullException(nameof(documentSession));

            _documentSession = documentSession;
        }
        public void Save()
        {
            _documentSession.SaveChanges();
        }

        public void Add(Image image)
        {
            _documentSession.Insert(image);
        }

        public void Delete(Image image)
        {
            _documentSession.Delete(image);
        }
    }
}