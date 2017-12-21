using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Database;

namespace MyNote.Identity.Infrastructure.Services
{
    public class RegisterService : BaseService<MyIdentityDbContext>, IRegisterService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDataRepository<Organization> _organizationRepository;
        private readonly IDataRepository<User> _useRepository;

        public RegisterService(UserManager<ApplicationUser> userManager,
                                IDataRepository<Organization> organizationRepository,
                                IDataRepository<User> useRepository)
        {
            if (userManager == null) throw new ArgumentNullException(nameof(userManager));
            if (organizationRepository == null) throw new ArgumentNullException(nameof(organizationRepository));
            if (useRepository == null) throw new ArgumentNullException(nameof(useRepository));

            _userManager = userManager;
            _organizationRepository = organizationRepository;
            _useRepository = useRepository;
        }
        public Task<IdentityResult> Register(RegisterUserCommand command)
        {

            ApplicationUser applicationUser = null;
            applicationUser = new ApplicationUser(command);

            var identity = _userManager.CreateAsync(applicationUser, command.Password);



            return identity;

        }

    }
}