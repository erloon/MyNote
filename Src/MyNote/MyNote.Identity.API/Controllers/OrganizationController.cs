using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.API.Infrastructure;
using MyNote.Identity.API.Model;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Events;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;
using RawRabbit;


namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class OrganizationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IOrganizationQuery _organizationQuery;
        private readonly IMapper _mapper;

        public OrganizationController(IMediator mediator,
                                     IOrganizationQuery organizationQuery,
                                     UserManager<ApplicationUser> userManager,
                                     IMapper mapper)
            : base(userManager)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (organizationQuery == null) throw new ArgumentNullException(nameof(organizationQuery));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));


            _mediator = mediator;
            _organizationQuery = organizationQuery;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateOrganization model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var command = _mapper.Map<CreateOrganizationCommand>(model);
            var userId = GetUserId(this.HttpContext.User.Identity.Name);
            command.CreateBy = userId;
            command.UpdateBy = userId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> Address([FromBody] CreateAddress model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var command = _mapper.Map<CreateAddressCommand>(model);
            var userId = GetUserId(this.HttpContext.User.Identity.Name);
            command.CreateBy = userId;
            command.UpdateBy = userId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> Company([FromBody] CreateCompany model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var command = _mapper.Map<CreateCompanyCommand>(model);
            var userId = GetUserId(this.HttpContext.User.Identity.Name);
            command.CreateBy = userId;
            command.UpdateBy = userId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> User([FromBody] CreateUser model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var command = _mapper.Map<CreateUserCommand>(model);
            var userId = GetUserId(this.HttpContext.User.Identity.Name);
            command.CreateBy = userId;
            command.UpdateBy = userId;

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
        [Route("{organizationId}/{userId}")]
        public async Task<IActionResult> Users(Guid organizationId, Guid userId)
        {
            return new OkObjectResult(await _organizationQuery.GetUserAsync(organizationId, userId));
        }


    }
}