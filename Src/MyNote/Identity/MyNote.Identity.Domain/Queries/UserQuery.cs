using System;
using System.Threading.Tasks;
using Marten;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Database;

namespace MyNote.Identity.Domain.Queries
{
    public class UserQuery : IUserQuery
    {
        private readonly IDataRepository<User> _userRepository;

        public UserQuery(IDataRepository<User> userRepository)
        {
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));

            _userRepository = userRepository;
        }
        public User Get(string name)
        {
            var user = _userRepository.FirstOrDefaultAsync(predicate: x => x.ApplicationUser.Email.Equals(name),
                include: i => i.Include(x => x.ApplicationUser).Include(x=>x.UserTeams).Include(x=>x.UserProjects)).Result;
            return user;
        }
    }
}