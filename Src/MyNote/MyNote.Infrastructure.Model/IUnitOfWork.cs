using System;
using Microsoft.EntityFrameworkCore;

namespace MyNote.Infrastructure.Model
{
    public interface IUnitOfWork<TContext> : IDisposable
  
    {
        TContext Context { get; set; }
        void BeginTransaction();
        void Commit();
        TContext GetDbContext();
    }
}