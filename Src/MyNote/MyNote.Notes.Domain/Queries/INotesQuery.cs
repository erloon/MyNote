using System;
using System.Collections.Generic;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Queries
{
    public interface INotesQuery
    {
        Note Get(Guid id);
        List<Note> Get(List<Guid> noteIds);
        void GetFile(Guid fileId);
    }
}