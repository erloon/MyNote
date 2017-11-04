using System;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Infrastructure.Model
{
    public interface IDataRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        TEntity Get(Guid id);
    }
}