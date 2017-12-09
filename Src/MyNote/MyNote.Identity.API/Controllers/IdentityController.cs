using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.Domain.Model.DomainEvents;
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
        public async Task<IActionResult> CreateOrganization([FromBody] CreateFirstUserCommand command)
        {
            bool commandResult = false;
            commandResult = await _mediator.Send(command);
            return commandResult ? (IActionResult)Ok() : (IActionResult)BadRequest();
        }
    }
}