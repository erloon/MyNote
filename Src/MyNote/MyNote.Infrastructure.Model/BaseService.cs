using System;
using Microsoft.EntityFrameworkCore;

namespace MyNote.Infrastructure.Model
{
    public abstract class BaseService<TContext>
        where TContext : DbContext
    {
      

        public BaseService()
        {
         
        }

        public void PerformCommand(Action action)
        {
            action();
        }
    }
}