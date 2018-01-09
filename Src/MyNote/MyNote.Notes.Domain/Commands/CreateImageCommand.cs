using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.Domain.Commands
{
    public class CreateImageCommand : Command, IRequest<Image>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid OrganizationId { get; set; }
        public byte[] Content { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }

        public CreateImageCommand()
        {
            
        }
    }
}