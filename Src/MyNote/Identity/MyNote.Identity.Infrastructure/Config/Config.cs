using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace MyNote.Identity.Infrastructure.Config
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>()
            {
                new ApiResource("Notes","Notes service"),
                new ApiResource("Review", "Review service")
            };
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrl)
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "SpaUI",
                    ClientName = "MyNote SPA UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = {$"{clientsUrl["SpaUI"]}/"},
                    RequireConsent = false,
                    PostLogoutRedirectUris = {$"{clientsUrl["SpaUI"]}/"},
                    AllowedCorsOrigins = {$"{clientsUrl["SpaUI"]}"},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Notes",
                        "Review"
                    }
                }
            };
        }
    }
}