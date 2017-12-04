using MyNote.Infrastructure.Model;

namespace MyNote.Identity.Infrastructure.SeedWork
{
    public class UnitOfWork : IUnitOfWork<MyIdentityDbContext>
    {
        public MyIdentityDbContext Context { get; set; }
        public UnitOfWork(MyIdentityDbContext context)
        {
            Context = context;
            Context.ChangeTracker.AutoDetectChangesEnabled = true;
        }
        public void Dispose()
        {
            this.Context.Dispose();
        }

        public void BeginTransaction()
        {
            Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            Context.SaveChanges();
            if(Context.Database.CurrentTransaction==null)
                return;
            Context.Database.CommitTransaction();
        }

        MyIdentityDbContext IUnitOfWork<MyIdentityDbContext>.GetDbContext()
        {
           return this.Context;
        }
    }
}