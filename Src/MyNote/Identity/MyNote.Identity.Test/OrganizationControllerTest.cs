using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyNote.Identity.API.Controllers;
using MyNote.Identity.API.Model;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Identity.Test.Factories;
using MyNote.Identity.Test.Writables;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;
using NUnit.Framework;
using static Microsoft.EntityFrameworkCore.PagedList;

namespace MyNote.Identity.Test
{
    [TestFixture]
    public class OrganizationControllerTest
    {
        private Mock<IMediator> _mediator = null;
        private Mock<IOrganizationQuery> _organizationQuery = null;
        private Mock<IMapper> _mapper = null;
        private Mock<IOrganizationContextService> _organizationContextService = null;
        private Mock<IUserMenagerService> _userMenager = null;
        private Mock<ITimeService> _timeService = null;
        private Mock<IDomainEventsService> _domainEventService = null;

        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>(MockBehavior.Default);
            _organizationQuery = new Mock<IOrganizationQuery>(MockBehavior.Default);
            _mapper = new Mock<IMapper>(MockBehavior.Default);
            _organizationContextService = new Mock<IOrganizationContextService>(MockBehavior.Default);
            _userMenager = new Mock<IUserMenagerService>(MockBehavior.Default);
            _domainEventService = new Mock<IDomainEventsService>(MockBehavior.Default);
            _timeService = new Mock<ITimeService>(MockBehavior.Default);
        }


        private List<Organization> GetOrganizaations()
        {
            return new List<Organization>()
           {
               new Organization(OrganizationFactory.CreateCommand(),_timeService.Object,_domainEventService.Object)
           };
        }

        private Task<Organization> GetOrganizationTask()
        {
            return new Task<Organization>(() => GetOrganizaations().FirstOrDefault());
        }

        [Test]
        public void Organization_Get()
        {

            _organizationQuery.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(GetOrganizaations().AsQueryable().ToPagedList(1, 10)));
            _userMenager.Setup(x => x.GetUserId(It.IsAny<string>())).Returns(Guid.Parse("10D50A1A-2E56-480A-9EE5-95D855985C00"));

            var controller = new OrganizationController(_mediator.Object, _organizationQuery.Object,
                _userMenager.Object, _mapper.Object, _organizationContextService.Object);

            var result = controller.Get();
            var okResult = result.Result as OkObjectResult;

            Assert.IsNotNull(okResult);
        }

        [Test]
        public void Organization_Created_Succes()
        {
            CreateOrganization createOrganization = new CreateOrganization()
            {
                Address = new CreateAddress()
                {
                    Country = "Polska",
                    City = "Opole",
                    Number = "1",
                    Street = "Wrocławska"
                },
                Company = new CreateCompany()
                {
                    Address = new CreateAddress()
                    {
                        Country = "Polska",
                        City = "Opole",
                        Number = "1",
                        Street = "Wrocławska"
                    },
                    Name = "FIRMA 1",
                    RegistrationNumber = "123456789",
                    VatNumber = "456987123"
                },
                Name = "Organiacja 123"
            };

            var command = OrganizationFactory.CreateCommand();
            _mapper.Setup(x => x.Map<CreateOrganizationCommand>(It.IsAny<CreateOrganization>())).Returns(command);
            _userMenager.Setup(x => x.GetUserId(It.IsAny<string>())).Returns(Guid.Parse("10D50A1A-2E56-480A-9EE5-95D855985C00"));
            _mediator.Setup(x => x.Send(It.IsAny<CreateOrganizationCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetOrganizaations().FirstOrDefault());

            var controller = new OrganizationController(_mediator.Object, _organizationQuery.Object,
            _userMenager.Object, _mapper.Object, _organizationContextService.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "erloon")
                    }, "AuthTypeName"))
                }
            };

            var result = controller.Create(createOrganization);

            var okResult = result.Result as OkObjectResult;
            var organization = okResult.Value as Organization;

            Assert.IsNotNull(organization);
            Assert.IsNotNull(organization.Id);
        }

    }

}