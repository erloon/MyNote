using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.API.Model;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Queries;
using MyNote.Identity.Infrastructure.Services.Contracts;

namespace MyNote.Identity.API.Controllers
{
    public class UsersController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IOrganizationContextService _organizationContextService;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator,
            IOrganizationContextService organizationContextService,
            IMapper mapper)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (organizationContextService == null) throw new ArgumentNullException(nameof(organizationContextService));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));

            _mediator = mediator;
            _organizationContextService = organizationContextService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Users([FromBody]AddUserToTeam addUserToTeam)
        {
            if (addUserToTeam == null) throw new ArgumentNullException(nameof(addUserToTeam));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            AddUserToTeamCommand command = null;
            command = _mapper.Map<AddUserToTeamCommand>(addUserToTeam);
            command.UpdateBy = organizationContext.UserId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpDelete]
        public async Task<IActionResult> Users([FromBody] RemoveUserFromTeam removeUserFromTeam)
        {
            if (removeUserFromTeam == null) throw new ArgumentNullException(nameof(removeUserFromTeam));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            RemoveUserFromTeamCommand command = null;
            command = _mapper.Map<RemoveUserFromTeamCommand>(removeUserFromTeam);
            command.UpdateBy = organizationContext.UserId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }
    }
}