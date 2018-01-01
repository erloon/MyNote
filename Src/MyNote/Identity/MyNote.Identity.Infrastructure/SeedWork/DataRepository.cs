using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Infrastructure.SeedWork
{
    public class DataRepository<TEntity> : IDataRepository<TEntity>
        where TEntity : Entity

    {
        private readonly IUnitOfWork _unitOfWork;

        public DataRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWork = unitOfWork;
        }

        public void Add(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Insert(entity);
        }

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = new CancellationToken())
        {
            return _unitOfWork.GetRepository<TEntity>().InsertAsync(entity, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Update(entity);
        }

        public TEntity GetById(Guid id)
        {
            return _unitOfWork.GetRepository<TEntity>().GetFirstOrDefault(predicate: x => x.Id.Equals(id));
        }

        public void Delete(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Delete(entity);
        }

        public IPagedList<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                        int pageIndex = 0,
                                        int pageSize = 20,
                                        bool disableTracking = true)
        {
            return _unitOfWork.GetRepository<TEntity>().GetPagedList(predicate, orderBy, include, pageIndex, pageSize, disableTracking);
        }

        public Task<IPagedList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                            int pageIndex = 0,
                                            int pageSize = 20,
                                            bool disableTracking = true,
                                            CancellationToken cancellationToken = default(CancellationToken))
        {

            return _unitOfWork.GetRepository<TEntity>(). GetPagedListAsync(predicate, orderBy, include, pageIndex,
                pageSize, disableTracking, cancellationToken);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                bool disableTracking = true)
        {

            return _unitOfWork.GetRepository<TEntity>().GetFirstOrDefault(predicate, orderBy, include, disableTracking);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                            bool disableTracking = true)
        {
            return _unitOfWork.GetRepository<TEntity>()
                .GetFirstOrDefaultAsync(predicate, orderBy, include, disableTracking);
        }

        public List<TEntity> GetAll()
        {
            return _unitOfWork.GetRepository<TEntity>().GetAll().ToList();
        }
        public void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}