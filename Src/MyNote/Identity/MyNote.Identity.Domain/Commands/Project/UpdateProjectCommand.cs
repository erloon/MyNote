﻿using System;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Project
{
    public class UpdateProjectCommand : Command, IRequest<Model.Project>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid UpdateBy { get; set; }
    }
}