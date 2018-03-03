using System;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Test.Writables
{
    public class OrganizationWritable : Organization
    {
        public OrganizationWritable WithId(Guid id)
        {
            this.Id = id;
            return this;
        }

        public OrganizationWritable WithName(string name)
        {
            this.Name = name;
            return this;
        }

        public OrganizationWritable WithAddress(Address address)
        {
            this.Address = Address;
            return this;
        }

        public OrganizationWritable WithCompany(Company company)
        {
            this.Company = company;
            return this;
        }
    }
}