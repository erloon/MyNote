using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure.Services.Contracts;

namespace MyNote.Identity.API.Infrastructure
{
    public class BaseController : Controller
    {
        protected readonly IUserMenagerService _userMenagerService;
        //protected readonly UserManager<ApplicationUser> _userManager;

        public BaseController(IUserMenagerService userMenagerService)
        {
            //if (userManager == null) throw new ArgumentNullException(nameof(userManager));
            _userMenagerService = userMenagerService ?? throw new ArgumentNullException(nameof(userMenagerService));
            //_userManager = userManager;
        }

        //protected Guid GetUserId(string name)
        //{
        //    //var userId = Guid.Parse(_userManager.Users.FirstOrDefault(x => x.UserName.Equals(name)).Id);
        //    return _userMenagerService.GetUserId(name);
        //}

           

    }
}