using System;
using System.Linq;
using Moq;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Test.Factories;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;
using NUnit.Framework;

namespace MyNote.Identity.Test
{
    [TestFixture]
    public class OrganizationAggregateTest
    {
        private Mock<ITimeService> _timeService = null;
        private Mock<IDomainEventsService> _domainEventService = null;
        private DateTime _currentTime = DateTime.Parse("2018-01-01");

        [SetUp]
        public void Setup()
        {
            _timeService = new Mock<ITimeService>(MockBehavior.Default);
            _domainEventService = new Mock<IDomainEventsService>(MockBehavior.Default);
        }

        [Test]
        public void Organization_Create_Success()
        {
            var command = OrganizationFactory.CreateCommand();
            _timeService.Setup(x => x.GetCurrent()).Returns(_currentTime);

            var organization = new Organization(command, _timeService.Object, _domainEventService.Object);

            Assert.NotNull(organization);
            Assert.AreEqual(_currentTime, organization.Create);
            Assert.AreEqual(_currentTime, organization.Modification);
            Assert.NotNull(organization.Id);
            Assert.NotNull(organization.Address);
            Assert.NotNull(organization.Company);
            Assert.NotNull(organization.Address.Id);
            Assert.NotNull(organization.Company.Id);
            Assert.NotNull(organization.Company.Address);
            Assert.NotNull(organization.Company.Address.Id);
            Assert.AreEqual(organization.Id, organization.Company.OrganizationId);
        }

        [Test]
        public void Organization_Create_ThrowException_If_CompanyEmpty()
        {
            var command = OrganizationFactory.CreateCommand();
            command.Company = null;

            _timeService.Setup(x => x.GetCurrent()).Returns(_currentTime);

            Assert.Throws<DomainException>(() => new Organization(command, _timeService.Object, _domainEventService.Object));
        }

        [Test]
        public void Organization_Create_ThrowException_If_AddressEmpty()
        {
            var command = OrganizationFactory.CreateCommand();
            command.Address = null;

            _timeService.Setup(x => x.GetCurrent()).Returns(_currentTime);

            Assert.Throws<DomainException>(() => new Organization(command, _timeService.Object, _domainEventService.Object));
        }

        [Test]
        public void Organization_AddProject_Success()
        {
            var organizationCommand = OrganizationFactory.CreateCommand();
            _timeService.Setup(x => x.GetCurrent()).Returns(_currentTime);


            var organization = new Organization(organizationCommand, _timeService.Object, _domainEventService.Object);

            var projectCommand = ProjectFactories.CreateCommand(organization.Id);
            organization.AddProject(projectCommand, _timeService.Object, _domainEventService.Object);

            Assert.NotNull(organization.Projects);
            Assert.AreEqual(1, organization.Projects.Count);
            Assert.IsNotEmpty(organization.Projects.FirstOrDefault()?.Name);
            Assert.IsNotEmpty(organization.Projects.FirstOrDefault()?.Description);
            Assert.IsNotEmpty(organization.Projects.FirstOrDefault()?.Subject);
        }
    }
}