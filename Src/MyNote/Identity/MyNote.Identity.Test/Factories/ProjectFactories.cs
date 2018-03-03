using System;
using MyNote.Identity.Domain.Commands.Project;

namespace MyNote.Identity.Test.Factories
{
    public class ProjectFactories
    {
        private static readonly Guid _userId = Guid.Parse("21BEBE7F-E1B4-4649-B386-10130EC0E332");
        private static readonly Guid _organizationId = Guid.Parse("11BEBE7F-E1B4-4649-B386-10130EC0E332");

        public static CreateProjectCommand CreateCommand(Guid? organizationId)
        {
            return new CreateProjectCommand()
            {
                CreateBy = _userId,
                Description = "Opis",
                Name = "Projekt 1",
                OrganizationId = organizationId ?? _organizationId,
                StartDate = DateTime.Parse("2017-05-05"),
                Subject = "API wersja 2",
                UpdateBy = _userId
            };
        }
    }
}