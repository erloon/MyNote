using System;

namespace MyNote.Identity.API.Model
{
    public class CreateAddress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public Guid OrganizationId { get; set; }
    }
}