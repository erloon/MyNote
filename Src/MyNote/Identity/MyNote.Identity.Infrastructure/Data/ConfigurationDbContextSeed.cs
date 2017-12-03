using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Mappers;

namespace MyNote.Identity.Infrastructure.Data
{
    public class ConfigurationDbContextSeed
    {
        public async Task SeedAsync(ConfigurationDbContext context, IConfiguration configuration)
        {
            var clientUrls = new Dictionary<string, string>();

            clientUrls.Add("SpaUI", configuration.GetSection("SpaClient").Value);
            clientUrls.Add("NotesAPI", configuration.GetSection("NotesAPIClient").Value);
            clientUrls.Add("ReviewAPI", configuration.GetSection("ReviewAPIClient").Value);

            if (!context.Clients.Any())
            {
                foreach (var client in Config.Config.GetClients(clientUrls))
                {
                    await context.Clients.AddAsync(client.ToEntity());
                }
                await context.SaveChangesAsync();
            }


            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.Config.GetResources())
                {
                    await context.IdentityResources.AddAsync(resource.ToEntity());
                }
                await context.SaveChangesAsync();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var api in Config.Config.GetApis())
                {
                    await context.ApiResources.AddAsync(api.ToEntity());
                }

                await context.SaveChangesAsync();
            }
        }
    }
}