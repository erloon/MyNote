using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Model.Commands;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Infrastructure.Services.Contracts
{
    public interface IOrganizationService
    {
        Organization Create(CreateOrganizationCommand command, ITimeService timeService);
    }
}