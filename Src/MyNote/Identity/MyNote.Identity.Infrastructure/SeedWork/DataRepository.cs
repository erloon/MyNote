using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Infrastructure.SeedWork
{
    public class DataRepository<TEntity> : IDataRepository<TEntity>
        where TEntity : BaseEntity

    {
        private readonly IUnitOfWork<MyIdentityDbContext> _unitOfWork;
        private DbSet<TEntity> _dbSet;

        public DataRepository(IUnitOfWork<MyIdentityDbContext> unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _dbSet = SetDbSet(unitOfWork);
        }

        private DbSet<TEntity> SetDbSet(IUnitOfWork<MyIdentityDbContext> unitOfWork)
        {
            var context = unitOfWork.Context;
            return context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = new CancellationToken())
        {
            return _dbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (include != null)
            {
                query = include(query);
            }

            return query.Where(predicate).ToList();
        }

        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (include != null)
            {
                query = include(query);
            }

            return query.Where(predicate).ToListAsync();
        }

        public TEntity FirstOrDefault<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (include != null)
            {
                query = include(query);
            }

            return query.FirstOrDefault(predicate);
        }

        public Task<TEntity> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (include != null)
            {
                query = include(query);
            }

            return query.FirstOrDefaultAsync(predicate);
        }
    }
}