using System;
using System.Collections.Generic;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Queries
{
    public class NotesQuery : INotesQuery
    {
        public Note Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Note> Get(List<Guid> noteIds)
        {
            throw new NotImplementedException();
        }

        public void GetFile(Guid fileId)
        {
            throw new NotImplementedException();
        }
    }
}