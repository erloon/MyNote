using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using MyNote.Identity.API;

namespace MyNote.Tests.Identity.IntegrationTest
{
    public class IdentityIntegrationTestStartup : Startup
    {
        public IdentityIntegrationTestStartup(IConfiguration env) : base(env)
        {
        }

    }
}