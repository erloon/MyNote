using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;
using MyNote.Notes.Domain.Commands;
using MyNote.Notes.Domain.Model;
using MyNote.Notes.Domain.Queries;

namespace MyNote.Notes.API.Application
{
    public class NotesHandler : IRequestHandler<CreateNoteCommand, Note>,
        IRequestHandler<UpdateNoteCommand, Note>,
        IRequestHandler<DeleteNoteCommand, bool>,
        IRequestHandler<CreateFileCommand, File>,
        IRequestHandler<DeleteFileCommand, bool>,
        IRequestHandler<CreateImageCommand, Image>,
        IRequestHandler<DeleteImageCommand, bool>
    {
        private readonly IDomainEventsService _domainEventsService;
        private readonly ITimeService _timeService;
        private readonly INotesQuery _notesQuery;
        private readonly IFIleQuery _fileQuery;
        private readonly IImageQuery _imageQuery;

        public NotesHandler(IDomainEventsService domainEventsService, ITimeService timeService, INotesQuery notesQuery, IFIleQuery fileQuery, IImageQuery imageQuery)
        {
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (notesQuery == null) throw new ArgumentNullException(nameof(notesQuery));
            if (fileQuery == null) throw new ArgumentNullException(nameof(fileQuery));
            if (imageQuery == null) throw new ArgumentNullException(nameof(imageQuery));

            _domainEventsService = domainEventsService;
            _timeService = timeService;
            _notesQuery = notesQuery;
            _fileQuery = fileQuery;
            _imageQuery = imageQuery;
        }

        public async Task<Note> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            Note note = new Note(request, _timeService, _domainEventsService);
            return await Task.FromResult(note);
        }

        public async Task<Note> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = _notesQuery.Get(request.NoteId) ?? throw new DomainException("Note not exists", request.NoteId);
            note.Update(request,_timeService,_domainEventsService);
            return await Task.FromResult(note);
        }

        public async Task<bool> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = _notesQuery.Get(request.NoteId) ?? throw new DomainException("Note not exists", request.NoteId);
            note.Delete(request,_domainEventsService);
            return await Task.FromResult(true);
        }

        public async Task<File> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var file = new File(request,_timeService,_domainEventsService);
            return await Task.FromResult(file);
        }

        public async Task<bool> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var file = _fileQuery.Get(request.FileId) ?? throw new DomainException("Note not exists", request.FileId);
            file.Delete(request, _domainEventsService);
            return await Task.FromResult(true);
        }

        public async Task<Image> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var image = new Image(request, _timeService, _domainEventsService);
            return await Task.FromResult(image);
        }

        public async Task<bool> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var image = _imageQuery.Get(request.ImageId) ?? throw new DomainException("Note not exists", request.ImageId);
            image.Delete(request, _domainEventsService);
            return await Task.FromResult(true);
        }
    }
}