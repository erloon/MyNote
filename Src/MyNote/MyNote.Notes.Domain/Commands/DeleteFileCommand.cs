using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Notes.Domain.Commands
{
    public class DeleteFileCommand : Command, IRequest<bool>
    {
        public Guid FileId { get; set; }
        public Guid OrganizationId { get; set; }

        public DeleteFileCommand()
        {
            
        }
    }
}