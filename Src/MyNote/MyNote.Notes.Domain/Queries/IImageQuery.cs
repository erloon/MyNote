using System;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Queries
{
    public interface IImageQuery
    {
        Image Get(Guid id);
    }
}