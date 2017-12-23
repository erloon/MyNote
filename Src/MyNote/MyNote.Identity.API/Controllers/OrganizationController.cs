using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.API.Infrastructure;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Commands.Team;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class OrganizationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IOrganizationQuery _organizationQuery;
        private Guid UserContext;

        public OrganizationController(IMediator mediator, IOrganizationQuery organizationQuery, UserManager<ApplicationUser> userManager) : base(userManager)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (organizationQuery == null) throw new ArgumentNullException(nameof(organizationQuery));

            _mediator = mediator;
            _organizationQuery = organizationQuery;

            UserContext = GetUserId(this.HttpContext.User.Identity.Name);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateOrganizationCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            command.CreateBy = GetUserId(this.HttpContext.User.Identity.Name);
            command.UpdateBy = GetUserId(this.HttpContext.User.Identity.Name);

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> Address([FromBody] CreateAddressCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            command.CreateBy = UserContext;
            command.UpdateBy = UserContext;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> Company([FromBody] CreateCompanyCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            command.CreateBy = UserContext;
            command.UpdateBy = UserContext;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> User([FromBody] CreateUserCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            command.CreateBy = UserContext;
            command.UpdateBy = UserContext;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _organizationQuery.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return new OkObjectResult(await _organizationQuery.GetAsync(id));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            return new OkObjectResult(await _organizationQuery.GetAsync(name));
        }

        [HttpGet]
        [Route("{organizationId}")]
        public async Task<IActionResult> Users(Guid organizationId)
        {
            return new OkObjectResult(await _organizationQuery.GetUsersAsync(organizationId));
        }

        [HttpGet]
        [Route("{organizationId}/{UserId}")]
        public async Task<IActionResult> Users(Guid organizationId, Guid UserId)
        {
            return new OkObjectResult(await _organizationQuery.GetUserAsync(organizationId, UserId));
        }


    }
}