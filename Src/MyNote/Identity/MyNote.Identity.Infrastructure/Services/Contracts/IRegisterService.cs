using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Infrastructure.Services.Contracts
{
    public interface IRegisterService
    {
        Task<IdentityResult> Register(RegisterUserCommand register);
    }
}