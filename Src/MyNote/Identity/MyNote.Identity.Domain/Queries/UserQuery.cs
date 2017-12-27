using System;
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
            throw new System.NotImplementedException();
        }
    }
}