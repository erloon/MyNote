using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using MyNote.Infrastructure.Model.Entity;


namespace MyNote.Infrastructure.Model
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : BaseEntity
    {
        //private readonly IUnitOfWork _unitOfWork;
        private DbSet<TEntity> _dbSet;

        public DataRepository()
        {
           // if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

            //_unitOfWork = unitOfWork;
            //_dbSet = _unitOfWork.GetDbContext().Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
           _dbSet.Add(entity);
            return entity;
        }
        public TEntity Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}