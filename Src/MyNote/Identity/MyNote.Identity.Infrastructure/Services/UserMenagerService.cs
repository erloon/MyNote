using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure.Services.Contracts;

namespace MyNote.Identity.Infrastructure.Services
{
    public class UserMenagerService : IUserMenagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserMenagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public Guid GetUserId(string name)
        {
            return Guid.Parse(_userManager.Users.FirstOrDefault(x => x.UserName.Equals(name)).Id);
        }
    }
}