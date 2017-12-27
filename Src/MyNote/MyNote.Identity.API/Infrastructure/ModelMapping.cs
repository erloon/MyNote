using AutoMapper;
using MyNote.Identity.API.Model;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Commands.Team;
using MyNote.Identity.Domain.Commands.User;

namespace MyNote.Identity.API.Infrastructure
{
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            CreateMap<CreateOrganizationCommand, CreateOrganization>()
                .ReverseMap();
            CreateMap<CreateAddressCommand, CreateAddress>()
                .ReverseMap();
            CreateMap<CreateCompanyCommand, CreateCompany>()
                .ReverseMap();
            CreateMap<LoginCommand, Login>()
                .ReverseMap();
            CreateMap<RegisterUserCommand, RegisterUser>()
                .ReverseMap();
            CreateMap<CreateTeamCommand, CreateTeam>()
                .ReverseMap();
        }
    }
}