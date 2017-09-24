using System;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Address:BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
    }
}