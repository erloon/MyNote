using System;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Queries
{
    public interface IFIleQuery
    {
        File Get(Guid id);
    }
}