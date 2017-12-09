using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Model.Commands.User;

namespace MyNote.Identity.Infrastructure.Services.Contracts
{
    public interface IRegisterService
    {
        Task<IdentityResult> Register(RegisterUserCommand register, Organization organization);
    }
}