using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNote.MVC.Infrastructure;
using MyNote.MVC.Models;
using MyNote.MVC.Models.DTO;
using MyNote.MVC.Models.VM;
using RestSharp;

namespace MyNote.MVC.Application
{
    public class IdentityService : BaseService, IIdentityService
    {
        public IdentityService(string clientUrl, IStoreService storeService)
        : base(clientUrl, storeService)
        {

        }
        public async Task<Cookie> Login(Login login)
        {
            var body = Serialize(login);
            var response = await IdentityRequest<OkResult>("api/identity/Login", Method.POST, body);
           
            return response;
        }

        public async Task<IdentityResult> Register(RegisterUser registerUser)
        {
            var body = Serialize(registerUser);
            var response = await PerformRequest<IdentityResult>("api/identity/Register", Method.POST, body);
            return response;
        }

        public async Task<User> CreateFirstUser(RegisterUser registerUser, CreateUser createUser)
        {
            IdentityResult identityResult = await Register(registerUser);
            User user = null;
            if (identityResult.Succeeded)
            {
                user = await CreatUser(createUser);
            }

            return user;
        }

        public async Task<OrganizationContext> GetOrganizationContext()
        {
            return await PerformRequestWithCookie<OrganizationContext>("api/Organization/GetOrganizationContext", Method.GET);
        }

        public async Task<User> CreatUser(CreateUser createUser)
        {
            var body = Serialize(createUser);
            var response = await PerformRequestWithCookie<User>("api/Users/User", Method.POST, body);
            return response;
        }

        public async Task<Organization> CreateOrganization(CreateOrganization createOrganization)
        {
            var body = Serialize(createOrganization);
            var response = await PerformRequestWithCookie<Organization>("api/Organization/Create", Method.POST, body);
            return response;
        }

        public async Task AddProject(CreateProject createProject)
        {
            var body = Serialize(createProject);
           var project = await PerformRequestWithCookie<Project>("api/Project/Project", Method.POST, body);
        }

        public async Task AddTeam(CreateTeam createTeam)
        {
            var body = Serialize(createTeam);
            var team = await PerformRequestWithCookie<Team>("api/Teams/Team", Method.POST, body);
        }
    }
}