﻿using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class RemoveResourceFromTeamCommand : Command, IRequest<bool>
    {
        public string OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid TeamId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}