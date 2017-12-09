using System;
using MyNote.Identity.Infrastructure;

namespace MyNote.Identity.API.Application.DomainHandler
{
    public class BaseHandler
    {
        private readonly MyIdentityDbContext _context;

        public BaseHandler(MyIdentityDbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public void PerformCommand<TCommand>(TCommand command, Action action)
        {
            try
            {
                _context.Database.BeginTransaction();
                action();
                _context.SaveChanges();
                _context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
            }
        }
    }
}