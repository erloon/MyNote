using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyNote.MVC.Models;
using MyNote.MVC.Models.DTO;
using MyNote.MVC.Models.VM;

namespace MyNote.MVC.Application
{
    public interface IIdentityService
    {
        Task<Cookie> Login(Login login);
        Task<IdentityResult> Register(RegisterUser registerUser);
        Task<User> CreatUser(CreateUser createUser);
        Task<Organization> CreateOrganization(CreateOrganization createOrganization);
        Task<User> CreateFirstUser(RegisterUser registerUser, CreateUser createUser);
        Task<OrganizationContext> GetOrganizationContext();
        Task AddProject(CreateProject createProject);
        Task AddTeam(CreateTeam createTeam);
    }
}