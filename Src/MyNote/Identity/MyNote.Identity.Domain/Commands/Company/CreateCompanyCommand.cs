using System;
using MediatR;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Company
{
    public class CreateCompanyCommand : Command
    {
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
        public CreateAddressCommand Address { get; set; }

        public CreateCompanyCommand()
        {

        }

        public CreateCompanyCommand(string name, string vatNumber, string registrationNumber, CreateAddressCommand address)
        {
            Name = name;
            VatNumber = vatNumber;
            RegistrationNumber = registrationNumber;
            this.Address = address;

        }
    }
}