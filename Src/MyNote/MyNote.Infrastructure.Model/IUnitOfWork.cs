using System;
using Microsoft.EntityFrameworkCore;

namespace MyNote.Infrastructure.Model
{
    public interface IUnitOfWork<TContext> : IDisposable
        where TContext: DbContext
    {
        void BeginTransaction();
        void Commit();
        TContext GetDbContext();
    }
}