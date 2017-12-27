using System.Threading.Tasks;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Infrastructure.Services.Contracts
{
    public interface ILoginService
    {
        Task<bool> ValidateCredentials(ApplicationUser user, string password);
        Task<ApplicationUser> FindByUsernameAndOrganization(LoginCommand login);
    }
}