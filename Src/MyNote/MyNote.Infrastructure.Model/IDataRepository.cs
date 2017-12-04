using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Infrastructure.Model
{
    public interface IDataRepository<TEntity>
        where TEntity : BaseEntity
    {

        void Add(TEntity entity);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        void Update(TEntity entity);
        TEntity GetById(Guid id);
        void Delete(TEntity entity);
        List<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        TEntity FirstOrDefault<TResult>(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

    }
}