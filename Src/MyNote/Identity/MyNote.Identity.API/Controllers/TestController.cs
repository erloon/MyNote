using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure.MigrationData;
using MyNote.Infrastructure.Model;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {
        private readonly IUnitOfWork<MyIdentityDbContext> _unitOfWork;

        public TestController(IUnitOfWork<MyIdentityDbContext> unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWork = unitOfWork;
        }

        public IActionResult Test()
        {
            //_unitOfWork.BeginTransaction();
            //DateTime now = DateTime.Now;

            //Company company = new Company()
            //{
            //    Id = Guid.NewGuid(),
            //    Address = new Address()
            //    {
            //        Id = Guid.NewGuid(),
            //        City = "Warszawa",
            //        Country = "Polska",
            //        Street = "Rzepichy",
            //        Create = now,
            //        CreateBy = Guid.NewGuid()
            //    },
            //    Create = now,
            //    CreateBy = Guid.NewGuid()
            //};

            //_unitOfWork.Commit();
            return RedirectToPage("/Index");
        }
    }
}