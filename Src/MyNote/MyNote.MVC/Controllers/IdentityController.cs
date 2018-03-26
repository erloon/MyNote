using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Isam.Esent.Interop;
using MyNote.MVC.Application;
using MyNote.MVC.Infrastructure;
using MyNote.MVC.Models.DTO;
using MyNote.MVC.Models.VM;

namespace MyNote.MVC.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IStoreService _storeService;
        private const string _AuthCookies = "AuthCookies";
        public IdentityController(IIdentityService identityService, IStoreService storeService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
        }
        public IActionResult Register()
        {
            return View(new RegisterUser());
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new Login());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var cookie = await _identityService.Login(model);
                if (cookie != null)
                {
                    //await HttpContext.SignInAsync();
                    await SignToHttp(model);
                    _storeService.Cookie = cookie;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }



        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUser model)
        {

            if (ModelState.IsValid)
            {
                TempData["OrganizationName"] = model.Organization;
                TempData["UserName"] = model.Email;
                var result = await _identityService.Register(model);
                if (result.Succeeded)
                {

                    Login login = new Login(model);
                    var cookie = await _identityService.Login(login);
                    await SignToHttp(login);
                    if (cookie != null)
                    {
                        _storeService.Cookie = cookie;
                        if (model.FirstOrganization)
                        {
                            return RedirectToAction("NewOrganization", "Identity");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewOrganization(CreateOrganization createOrganization)
        {
            if (createOrganization.Company != null && createOrganization.Address != null)
            {
                createOrganization.Name = TempData["OrganizationName"].ToString();
                var organization = await _identityService.CreateOrganization(createOrganization);

                if (organization != null)
                {
                    var user = await _identityService.CreatUser(new CreateUser()
                    {
                        UserName = TempData["UserName"].ToString(),
                        IsAdministrator = true,
                        OrganizationId = organization.Id
                    });

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(createOrganization);
        }

        public IActionResult NewOrganization()
        {
            return View("NewOrganization", new CreateOrganization());
        }

        private async Task SignToHttp(Login login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Email),
                new Claim("Organization",login.Organization)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }

        public async Task<IActionResult> CreateProject(CreateProject createProject)
        {
            await _identityService.AddProject(createProject);
            return RedirectToAction("CreateNote", "Notes");
        }

        public async Task<IActionResult> CreateTeam(CreateTeam createTeam)
        {
            await _identityService.AddTeam(createTeam);
            return RedirectToAction("CreateNote", "Notes");
        }

        public IActionResult Projects()
        {
            throw new NotImplementedException();
        }

        public IActionResult Teams()
        {
            throw new NotImplementedException();
        }
    }
}