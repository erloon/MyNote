using System;
using System.Threading.Tasks;
using MyNote.Identity.Domain;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Infrastructure.Services.Contracts
{
    public interface IOrganizationContextService
    {
        Task<OrganizationContext> Get(string userName);
    }
}