using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Infrastructure.Services.Contracts
{
    public interface IOrganizationService
    {
        Organization Create(CreateOrganizationCommand command, ITimeService timeService);
    }
}