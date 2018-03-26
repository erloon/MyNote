using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.API.Model;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Identity.Domain.Queries;
using MyNote.Identity.Infrastructure.Services.Contracts;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IOrganizationContextService _organizationContextService;
        private readonly IProjectQuery _projectQuery;

        public ProjectController(IMediator mediator,
                                 IMapper mapper,
                                 IOrganizationContextService organizationContextService,
                                 IProjectQuery projectQuery)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            if (organizationContextService == null) throw new ArgumentNullException(nameof(organizationContextService));
            if (projectQuery == null) throw new ArgumentNullException(nameof(projectQuery));

            _mediator = mediator;
            _mapper = mapper;
            _organizationContextService = organizationContextService;
            _projectQuery = projectQuery;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _projectQuery.GetAllAsync(organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _projectQuery.GetAsync(id, organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _projectQuery.GetAsync(name, organizationContext.OrganizationId));
        }

        [HttpPost]
        public async Task<IActionResult> Project([FromBody]CreateProject project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            var command = _mapper.Map<CreateProjectCommand>(project);
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
        public async Task<IActionResult> Project([FromBody]UpdateProject project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);

            var command = _mapper.Map<UpdateProjectCommand>(project);
            command.UpdateBy = organizationContext.UserId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }
        [HttpDelete]
        public async Task<IActionResult> Project([FromBody]DeleteProject deleteProject)
        {
            if (deleteProject == null) throw new ArgumentNullException(nameof(deleteProject));
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            var command = _mapper.Map<DeleteProjectCommand>(deleteProject);
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
            return new OkObjectResult(await _projectQuery.GetUsersAsync(teamId, organizationContext.OrganizationId));
        }

        [HttpGet]
        [Route("{teamId}/{UserId}")]
        public async Task<IActionResult> Users(Guid userId, Guid teamId)
        {
            var organizationContext = await _organizationContextService.Get(this.HttpContext.User.Identity.Name);
            return new OkObjectResult(await _projectQuery.GetUserAsync(teamId, userId, organizationContext.OrganizationId));
        }

    }
}