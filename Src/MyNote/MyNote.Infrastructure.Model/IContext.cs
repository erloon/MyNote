using Microsoft.EntityFrameworkCore;

namespace MyNote.Infrastructure.Model
{
    public interface IContext<TContext> where TContext : DbContext
    {

    }
}