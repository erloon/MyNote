using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNote.MVC.Application;
using MyNote.MVC.Models.VM;

namespace MyNote.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IIdentityService _identityService;

        public HomeController(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }
        public async Task<IActionResult> Index(HomePageVM homePageVm)
        {
            
            if (homePageVm.OrganizationContext == null)
            {
                var organizationContext = await _identityService.GetOrganizationContext();
                homePageVm = new HomePageVM()
                {
                    OrganizationContext = organizationContext
                };

                homePageVm.OrganizationContext.AddAvailableProjects();
                homePageVm.OrganizationContext.AddAvailableTeamsList();
            }
            return View(homePageVm);
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
