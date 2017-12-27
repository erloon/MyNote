using System;

namespace MyNote.Identity.API.Model
{
    public class CreateCompany
    {
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public Guid AddressId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}