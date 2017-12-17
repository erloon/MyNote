﻿using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class RemoveResourceFromProjectCommand : BaseCommand
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid ProjectId { get; set; }
    }
}