using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.API.Model;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class IdentityController : Controller
    {
        private readonly IMediator _mediator;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public IdentityController(IMediator mediator,
                                  SignInManager<ApplicationUser> signInManager,
                                  IMapper mapper)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (signInManager == null) throw new ArgumentNullException(nameof(signInManager));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));

            _mediator = mediator;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Register([FromBody]RegisterUser model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            var command = _mapper.Map<RegisterUserCommand>(model);
            var result = _mediator.Send(command).Result;

            if (result)
            {
                return new OkResult();
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Login model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var command = _mapper.Map<LoginCommand>(model);
            var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return new OkResult();
            }
            return new BadRequestResult();
        }
    }
}