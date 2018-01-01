using System;
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
                .ForMember(x => x.Address, o => o.MapFrom(s => s.Address))
                .ReverseMap();
            CreateMap<CreateUserCommand, CreateUser>()
                .ReverseMap();

            CreateMap<LoginCommand, Login>()
                .ReverseMap();
            CreateMap<RegisterUserCommand, RegisterUser>()
                .ReverseMap();

            CreateMap<CreateTeamCommand, CreateTeam>()
                .ReverseMap();
            CreateMap<UpdateTeamCommand, UpdateTeam>()
                .ReverseMap();
            CreateMap<DeleteTeamCommand, DeleteTeam>()
                .ReverseMap();
            CreateMap<AddUserToTeamCommand, AddUserToTeam>()
                .ReverseMap();

        }
    }
}