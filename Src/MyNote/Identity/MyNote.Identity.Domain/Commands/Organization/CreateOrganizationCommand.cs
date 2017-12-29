using System;
using MediatR;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Organization
{
    public class CreateOrganizationCommand : Command, IRequest<Model.Organization>
    {
        public string Name { get; set; }
        public CreateCompanyCommand Company { get; set; }
        public CreateAddressCommand Address { get; set; }
        public Guid? CreateBy { get; set; }
        public Guid? UpdateBy { get; set; }

        public CreateOrganizationCommand()
        {
            
        }
    }
}