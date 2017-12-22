using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.API.Infrastructure
{
    public class BaseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public BaseController(UserManager<ApplicationUser> userManager)
        {
            if (userManager == null) throw new ArgumentNullException(nameof(userManager));
            _userManager = userManager;
        }

        protected Guid GetUserId(string name)
        {
            var userId = Guid.Parse(_userManager.Users.FirstOrDefault(x => x.UserName.Equals(name)).Id);
            return userId;
        }

           

    }
}