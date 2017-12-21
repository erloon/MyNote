using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model.DTOs;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class IdentityController : Controller
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));

            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var result = await _mediator.Send(command);

            if (result)
            {
                return new OkResult();
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var result = await _mediator.Send(command);

            if (result)
            {
                return new OkResult();
            }
            return new BadRequestResult();
        }
    }
}