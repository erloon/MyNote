using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure.MigrationData;
using MyNote.Infrastructure.Model;

namespace MyNote.Identity.API.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly IUnitOfWork<MyIdentityDbContext> _unitOfWork;

        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, IUnitOfWork<MyIdentityDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _signInManager = signInManager;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Index");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Test()
        {
            _unitOfWork.BeginTransaction();
            DateTime now = DateTime.Now;

            Company company = new Company()
            {
                Id = Guid.NewGuid(),
                Address = new Address()
                {
                    Id = Guid.NewGuid(),
                    City = "Warszawa",
                    Country = "Polska",
                    Street = "Rzepichy",
                    Create = now,
                    CreateBy = Guid.NewGuid()
                },
                Create = now,
                CreateBy = Guid.NewGuid()
            };

            _unitOfWork.Commit();
            return RedirectToPage("/Index");
        }
    }
}
