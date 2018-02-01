using System;

namespace MyNote.MVC.Models.DTO
{
    public class Company
    {
        public string Name { get; protected set; }
        public Address Address { get; protected set; }
        public Guid AddressId { get; set; }
        public string VatNumber { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public Guid OrganizationId { get; protected set; }
        public Organization Organization { get; protected set; }

        public Company()
        {
        }
    }
}