using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNote.Notes.API.Infrastructure;
using MyNote.Notes.API.Model;
using MyNote.Notes.Domain.Commands;
using MyNote.Notes.Domain.Queries;

namespace MyNote.Notes.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class NotesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotesQuery _notesQuery;

        public NotesController(IMediator mediator,
                                IMapper mapper,
                                INotesQuery notesQuery)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            if (notesQuery == null) throw new ArgumentNullException(nameof(notesQuery));

            _mediator = mediator;
            _mapper = mapper;
            _notesQuery = notesQuery;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNote createNote)
        {
            if (createNote == null) throw new ArgumentNullException(nameof(createNote));
            var userContext = GetUserClaims(this.HttpContext.User);

            var command = _mapper.Map<CreateNoteCommand>(createNote);
            command.CreateBy = userContext.UserId;
            command.OrganizationId = userContext.OrganizationId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateNote updateNote)
        {
            if (updateNote == null) throw new ArgumentNullException(nameof(updateNote));
            var userContext = GetUserClaims(this.HttpContext.User);

            var command = _mapper.Map<UpdateNoteCommand>(updateNote);
            command.UpdateBy = userContext.UserId;
            command.OrganizationId = userContext.OrganizationId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteNote deleteNote)
        {
            if (deleteNote == null) throw new ArgumentNullException(nameof(deleteNote));
            var userContext = GetUserClaims(this.HttpContext.User);

            var command = _mapper.Map<DeleteNoteCommand>(deleteNote);
            command.OrganizationId = userContext.OrganizationId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromBody] Guid id)
        {
            return new OkObjectResult(_notesQuery.Get(id));
        }

        [HttpGet]
        [Route("{ids}")]
        public async Task<IActionResult> Get([FromBody] List<Guid> ids)
        {
            return new OkObjectResult(_notesQuery.Get(ids));
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage([FromBody] CreateImage createImage)
        {
            if (createImage == null) throw new ArgumentNullException(nameof(createImage));

            var userContext = GetUserClaims(this.HttpContext.User);

            var command = _mapper.Map<CreateImageCommand>(createImage);
            command.OrganizationId = userContext.OrganizationId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage([FromBody] DeleteImageCommand deleteImage)
        {
            if (deleteImage == null) throw new ArgumentNullException(nameof(deleteImage));

            var userContext = GetUserClaims(this.HttpContext.User);

            var command = _mapper.Map<DeleteImageCommand>(deleteImage);
            command.OrganizationId = userContext.OrganizationId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFile([FromBody] CreateFile createFile)
        {
            if (createFile == null) throw new ArgumentNullException(nameof(createFile));

            var userContext = GetUserClaims(this.HttpContext.User);

            var command = _mapper.Map<CreateFileCommand>(createFile);
            command.OrganizationId = userContext.OrganizationId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFile([FromBody] DeleteFileCommand deleteFile)
        {
            if (deleteFile == null) throw new ArgumentNullException(nameof(deleteFile));

            var userContext = GetUserClaims(this.HttpContext.User);

            var command = _mapper.Map<DeleteFileCommand>(deleteFile);
            command.OrganizationId = userContext.OrganizationId;

            var result = await _mediator.Send(command);

            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }



    }
}