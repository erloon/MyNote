using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.API.Infrastructure;
using MyNote.Identity.API.Model;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Queries;
using MyNote.Identity.Infrastructure.Services.Contracts;


namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class OrganizationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IOrganizationQuery _organizationQuery;
        private readonly IMapper _mapper;
        private readonly IOrganizationContextService _organizationContextService;

        public OrganizationController(IMediator mediator,
                                     IOrganizationQuery organizationQuery,
                                     IUserMenagerService userMenagerService,
                                     IMapper mapper,
                                     IOrganizationContextService organizationContextService)
            : base(userMenagerService)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (organizationQuery == null) throw new ArgumentNullException(nameof(organizationQuery));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));


            _mediator = mediator;
            _organizationQuery = organizationQuery;
            _mapper = mapper;
            _organizationContextService = organizationContextService ?? throw new ArgumentNullException(nameof(organizationContextService));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateOrganization model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            CreateOrganizationCommand command;

            command = _mapper.Map<CreateOrganizationCommand>(model);

            var userId = _userMenagerService.GetUserId(this.HttpContext.User.Identity.Name);
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
            CreateUserCommand command = null;
            command = _mapper.Map<CreateUserCommand>(model);

            var userId = _userMenagerService.GetUserId(this.HttpContext.User.Identity.Name);
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
        [Route("{id:guid}")]
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

        [HttpGet]
        public async Task<IActionResult> GetOrganizationContext()
        {
            return new OkObjectResult(await _organizationContextService.Get(this.HttpContext.User.Identity.Name));
        }
    }
}