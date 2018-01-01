using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.API.Model;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Queries;
using MyNote.Identity.Infrastructure.Services.Contracts;
using Newtonsoft.Json;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IOrganizationContextService _organizationContextService;
        private readonly IMapper _mapper;
        private readonly IUserQuery _userQuery;

        public UsersController(IMediator mediator,
                                IOrganizationContextService organizationContextService,
                                IMapper mapper,
                                IUserQuery userQuery)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (organizationContextService == null) throw new ArgumentNullException(nameof(organizationContextService));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            if (userQuery == null) throw new ArgumentNullException(nameof(userQuery));

            _mediator = mediator;
            _organizationContextService = organizationContextService;
            _mapper = mapper;
            _userQuery = userQuery;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _userQuery.GetAllAsync(organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _userQuery.GetAsync(id, organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _userQuery.GetAsync(name, organizationContext.OrganizationId));
        }

        [HttpPost]
        public async Task<IActionResult> User([FromBody]CreateUser team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            var command = _mapper.Map<CreateUserCommand>(team);
            command.OrganizationId = organizationContext.OrganizationId;
            command.ApplicationUser = organizationContext.ApplicationUser;
            command.CreateBy = organizationContext.UserId;
            command.UpdateBy = organizationContext.UserId;


            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPut]
        public async Task<IActionResult> User([FromBody]UpdateUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            var command = _mapper.Map<UpdateUserCommand>(user);
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
        public async Task<IActionResult> User([FromBody] DeleteUser deleteUser)
        {
            if (deleteUser == null) throw new ArgumentNullException(nameof(deleteUser));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            var command = _mapper.Map<DeleteUserCommand>(deleteUser);
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

        [HttpPost]
        public async Task<IActionResult> AddUserToTeam([FromBody]AddUserToTeam addUserToTeam)
        {
            if (addUserToTeam == null) throw new ArgumentNullException(nameof(addUserToTeam));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            AddUserToTeamCommand command = null;
            command = _mapper.Map<AddUserToTeamCommand>(addUserToTeam);
            command.OrganizationId = organizationContext.OrganizationId;
            command.UpdateBy = organizationContext.UserId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUserFromTeam([FromBody]RemoveUserFromTeam removeUserFromTeam)
        {
            if (removeUserFromTeam == null) throw new ArgumentNullException(nameof(removeUserFromTeam));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            RemoveUserFromTeamCommand command = null;
            command = _mapper.Map<RemoveUserFromTeamCommand>(removeUserFromTeam);
            command.OrganizationId = organizationContext.OrganizationId;
            command.UpdateBy = organizationContext.UserId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToProject([FromBody]AddUserToProject addUserToProject)
        {
            if (addUserToProject == null) throw new ArgumentNullException(nameof(addUserToProject));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            AddUserToProjectCommand command = null;
            command = _mapper.Map<AddUserToProjectCommand>(addUserToProject);
            command.OrganizationId = organizationContext.OrganizationId;
            command.UpdateBy = organizationContext.UserId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUserFromProject([FromBody]RemoveUserFromProject removeUserFromProject)
        {
            if (removeUserFromProject == null) throw new ArgumentNullException(nameof(removeUserFromProject));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            RemoveUserFromProjectCommand command = null;
            command = _mapper.Map<RemoveUserFromProjectCommand>(removeUserFromProject);
            command.OrganizationId = organizationContext.OrganizationId;
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