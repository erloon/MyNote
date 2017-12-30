using System;
using System.Collections.Generic;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Infrastructure.Model.Entity
{
    public abstract class BaseEntity
    {

        protected BaseEntity()
        {

        }
        public Guid Id { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }

    }
}