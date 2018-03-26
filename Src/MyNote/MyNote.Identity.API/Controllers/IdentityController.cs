using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.API.Model;
using MyNote.Identity.Domain;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model.API;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class IdentityController : Controller
    {
        private readonly IMediator _mediator;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IOrganizationContextService _organizationContextService;

        public IdentityController(IMediator mediator,
                                  SignInManager<ApplicationUser> signInManager,
                                  IMapper mapper,
                                  IOrganizationContextService organizationContextService)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (signInManager == null) throw new ArgumentNullException(nameof(signInManager));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));

            _mediator = mediator;
            _signInManager = signInManager;
            _mapper = mapper;
            _organizationContextService = organizationContextService ?? throw new ArgumentNullException(nameof(organizationContextService));
        }

        [HttpPost]
        public IActionResult Register([FromBody]RegisterUser model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            var command = _mapper.Map<RegisterUserCommand>(model);
            var result = _mediator.Send(command).Result;

            if (result.Succeeded)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Login model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var command = _mapper.Map<LoginCommand>(model);
            var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, lockoutOnFailure: false);


            var organizationContext = await _organizationContextService.Get(command.Email);
            AddClaims(organizationContext);

            if (result.Succeeded)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        private void AddClaims(OrganizationContext organizationContext)
        {
            var claimsIdentity = this.HttpContext.User.Identity as ClaimsIdentity;

            claimsIdentity.AddClaims(new Claim[]
            {
                new Claim("userId", organizationContext.UserId.ToString()),
            });
            claimsIdentity.AddClaims(new Claim[]
            {
                new Claim("organizationId", organizationContext.OrganizationId.ToString()),
            });
        }
    }
}