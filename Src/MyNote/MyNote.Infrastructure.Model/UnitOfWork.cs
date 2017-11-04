using System;
using Microsoft.EntityFrameworkCore;

namespace MyNote.Infrastructure.Model
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> 
        where TContext : DbContext
    {
        private readonly TContext _dbContext;
        public UnitOfWork()
        {
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }

        public TContext GetDbContext()
        {
            return _dbContext;
        }
    }
}