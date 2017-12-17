using System;
using System.Collections.Generic;
using MediatR;

namespace MyNote.Infrastructure.Model.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modyfication { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
        
    }
}