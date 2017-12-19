using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class CreateResourceCommand : Command
    {
        public string OwnerId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid? ContentId { get; set; }
    }
}