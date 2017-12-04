using System;
using Microsoft.EntityFrameworkCore;

namespace MyNote.Infrastructure.Model
{
    public abstract class BaseService<TContext>
        where TContext : DbContext
    {
        private readonly IUnitOfWork<TContext> _unitOfWork;

        public BaseService(IUnitOfWork<TContext> unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public void PerformCommand(Action action)
        {
            _unitOfWork.BeginTransaction();

            action();

            _unitOfWork.Context.SaveChanges();
            _unitOfWork.Commit();
        }
    }
}