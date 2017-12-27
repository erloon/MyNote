using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries
{
    public interface IUserQuery
    {
        User Get(string name);
    }
}