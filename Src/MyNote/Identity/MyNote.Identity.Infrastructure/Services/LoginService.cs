using System;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Database;

namespace MyNote.Identity.Infrastructure.Services
{
    public class LoginService : ILoginService
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        private readonly IDataRepository<User> _useRepository;

        public LoginService(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            IDataRepository<User> useRepository)
        {
            if (userManager == null) throw new ArgumentNullException(nameof(userManager));
            if (signInManager == null) throw new ArgumentNullException(nameof(signInManager));
            if (useRepository == null) throw new ArgumentNullException(nameof(useRepository));

            _userManager = userManager;
            _signInManager = signInManager;
            _useRepository = useRepository;
        }

        public async Task<bool> ValidateCredentials(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<ApplicationUser> FindByUsernameAndOrganization(LoginCommand login)
        {
            User user = new User();
            //var user = await _useRepository.FirstOrDefaultAsync(
            //    x => x.Organization.Name.Equals(login.Organization) && x.ApplicationUser.Email.Equals(login.Email), null,
            //    s => s.Include(x => x.Organization));
            return user.ApplicationUser;
        }
    }
}