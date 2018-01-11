using System;
using System.Threading;
using System.Threading.Tasks;
using Marten.Linq.SoftDeletes;
using MediatR;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Notes.Domain.Events;
using MyNote.Notes.Domain.Model;
using MyNote.Notes.Domain.Repositories;
using MyNote.Notes.Infrastructure;

namespace MyNote.Notes.Domain.Queries.Handlers
{
    public class NoteEventHandler : INotificationHandler<NoteCreated>,
                                    INotificationHandler<NoteDeleted>,
                                    INotificationHandler<NoteUpdated>,
                                    INotificationHandler<FileCreated>,
                                    INotificationHandler<FileDeleted>,
                                    INotificationHandler<ImageCreated>,
                                    INotificationHandler<ImageDeleted>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IImageRepository _imageRepository;
        private readonly INotesQuery _notesQuery;
        private readonly IFIleQuery _fileQuery;
        private readonly IImageQuery _imageQuery;

        public NoteEventHandler(INoteRepository noteRepository,
                                IFileRepository fileRepository,
                                IImageRepository imageRepository, 
                                INotesQuery notesQuery,
                                IFIleQuery fileQuery,
                                IImageQuery imageQuery)
        {
            if (noteRepository == null) throw new ArgumentNullException(nameof(noteRepository));
            if (fileRepository == null) throw new ArgumentNullException(nameof(fileRepository));
            if (imageRepository == null) throw new ArgumentNullException(nameof(imageRepository));
            if (notesQuery == null) throw new ArgumentNullException(nameof(notesQuery));
            if (fileQuery == null) throw new ArgumentNullException(nameof(fileQuery));
            if (imageQuery == null) throw new ArgumentNullException(nameof(imageQuery));

            _noteRepository = noteRepository;
            _fileRepository = fileRepository;
            _imageRepository = imageRepository;
            _notesQuery = notesQuery;
            _fileQuery = fileQuery;
            _imageQuery = imageQuery;
        }
        public Task Handle(NoteCreated notification, CancellationToken cancellationToken)
        {
            Note note = new Note();
            note.Apply(notification);
            _noteRepository.Add(note);
            _noteRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(NoteDeleted notification, CancellationToken cancellationToken)
        {
            var note = _notesQuery.Get(notification.NoteId) ?? throw new DomainException("Note not exists", notification.NoteId);
            _noteRepository.Delete(note);
            _noteRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(NoteUpdated notification, CancellationToken cancellationToken)
        {
            var note = _notesQuery.Get(notification.NoteId) ?? throw new DomainException("Note not exists", notification.NoteId);
            note.Apply(notification);
            _noteRepository.Update(note);
            _noteRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(FileCreated notification, CancellationToken cancellationToken)
        {
            File file = new File();
            file.Apply(notification);
            _fileRepository.Add(file);
            _fileRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(FileDeleted notification, CancellationToken cancellationToken)
        {
            var file = _fileQuery.Get(notification.FileId) ?? throw new DomainException("File not exists", notification.FileId);
            _fileRepository.Delete(file);
            _fileRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(ImageCreated notification, CancellationToken cancellationToken)
        {
            Image image = new Image();
            image.Apply(notification);
            _imageRepository.Add(image);
            _imageRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(ImageDeleted notification, CancellationToken cancellationToken)
        {
            var image = _imageQuery.Get(notification.ImageId) ?? throw new DomainException("Image not exists", notification.ImageId);
            _imageRepository.Delete(image);
            _imageRepository.Save();
            return Task.CompletedTask;
        }
    }
}