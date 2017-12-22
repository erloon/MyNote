using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Model.DTOs;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class IdentityController : Controller
    {
        private readonly IMediator _mediator;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityController(IMediator mediator, SignInManager<ApplicationUser> signInManager)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (signInManager == null) throw new ArgumentNullException(nameof(signInManager));

            _mediator = mediator;
            _signInManager = signInManager;
        }

        [HttpPost]
        public  IActionResult Register([FromBody]RegisterUserCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var result = _mediator.Send(command).Result;

            if (result)
            {
                return new OkResult();
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var result =  await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return new OkResult();
            }
            return new BadRequestResult();
        }
    }
}