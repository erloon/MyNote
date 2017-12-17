﻿using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Project
{
    public class AddResourceToProjectCommand : BaseCommand
    {
        public Guid ProjectId { get; set; }
        public Guid ResourceId { get; set; }
    }
}