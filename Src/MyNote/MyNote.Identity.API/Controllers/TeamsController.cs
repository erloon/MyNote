using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.API.Model;
using MyNote.Identity.Domain.Commands.Team;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Queries;
using MyNote.Identity.Infrastructure.Services.Contracts;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class TeamsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ITeamQuery _teamQuery;
        private readonly IOrganizationContextService _organizationContextService;
        private readonly IMapper _mapper;

        public TeamsController(IMediator mediator,
                                ITeamQuery teamQuery,
                                IOrganizationContextService organizationContextService,
                                IMapper mapper)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (teamQuery == null) throw new ArgumentNullException(nameof(teamQuery));
            if (organizationContextService == null) throw new ArgumentNullException(nameof(organizationContextService));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));

            _mediator = mediator;
            _teamQuery = teamQuery;
            _organizationContextService = organizationContextService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _teamQuery.GetAllAsync(organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _teamQuery.GetAsync(id, organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _teamQuery.GetAsync(name, organizationContext.OrganizationId));
        }

        [HttpPost]
        public async Task<IActionResult> Team([FromBody]CreateTeam team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            var command = _mapper.Map<CreateTeamCommand>(team);
            command.CreateBy = organizationContext.UserId;
            command.UpdateBy = organizationContext.UserId;
            command.OrganizationId = organizationContext.OrganizationId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPut]
        public async Task<IActionResult> Team([FromBody]UpdateTeam team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            var command = _mapper.Map<UpdateTeamCommand>(team);
            command.UpdateBy = organizationContext.UserId;
            command.OrganizationId = organizationContext.OrganizationId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Team([FromBody] DeleteTeam deleteTeam)
        {
            if (deleteTeam == null) throw new ArgumentNullException(nameof(deleteTeam));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            var command = _mapper.Map<DeleteTeamCommand>(deleteTeam);
            command.UpdateBy = organizationContext.UserId;
            command.OrganizationId = organizationContext.OrganizationId;

            try
            {
                await _mediator.Send(command);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet]
        [Route("{teamId}")]
        public async Task<IActionResult> Users(Guid teamId)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _teamQuery.GetUsersAsync(teamId, organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{teamId}/{UserId}")]
        public async Task<IActionResult> Users(Guid userId, Guid teamId)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _teamQuery.GetUserAsync(teamId, userId, organizationContext.OrganizationId));
        }

    }
}