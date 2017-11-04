using System;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Company :BaseEntity    
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Guid AddressId { get; set; }
        public string VatNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }


    }
}