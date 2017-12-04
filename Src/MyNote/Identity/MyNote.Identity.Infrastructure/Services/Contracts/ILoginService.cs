using System.Threading.Tasks;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Model.DTOs;

namespace MyNote.Identity.Infrastructure.Services.Contracts
{
    public interface ILoginService
    {
        Task<bool> ValidateCredentials(ApplicationUser user, string password);
        Task<ApplicationUser> FindByUsernameAndOrganization(Login login);
        Task SignIn(Login login);
    }
}