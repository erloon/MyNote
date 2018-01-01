using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.Domain.Queries;
using MyNote.Identity.Infrastructure.Services.Contracts;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ResourceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOrganizationContextService _organizationContextService;
        private readonly IMapper _mapper;
        private readonly ResourceQuery _resourceQuery;

        public ResourceController(IMediator mediator,
            IOrganizationContextService organizationContextService,
            IMapper mapper,
            ResourceQuery resourceQuery)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (organizationContextService == null) throw new ArgumentNullException(nameof(organizationContextService));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            if (resourceQuery == null) throw new ArgumentNullException(nameof(resourceQuery));

            _mediator = mediator;
            _organizationContextService = organizationContextService;
            _mapper = mapper;
            _resourceQuery = resourceQuery;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _resourceQuery.GetAllAsync(organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _resourceQuery.GetAsync(id, organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{resourceId}")]
        public async Task<IActionResult> Users(Guid resourceId)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _resourceQuery.GetUsersAsync(resourceId, organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{resourceId}/{UserId}")]
        public async Task<IActionResult> Users(Guid resourceId, Guid userId)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _resourceQuery.GetUserAsync(resourceId, userId, organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{teamId}")]
        public async Task<IActionResult> Team(Guid teamId)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _resourceQuery.GetByTeamAsync(teamId,organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{projectId}")]
        public async Task<IActionResult> Project(Guid projectId)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _resourceQuery.GetByProjectAsync(projectId, organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{userId}", Name = "GetForUser")]
        public async Task<IActionResult> User(Guid userId)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _resourceQuery.GetByUserAsync(userId, organizationContext.OrganizationId));
        }

    }
}