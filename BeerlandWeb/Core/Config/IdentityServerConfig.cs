using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace BeerlandWeb.Core.Config;

public static class IdentityServerConfig
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("BeerlandApi")
        };
    
    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new("BeerlandApi", "Beerland API", new []
            {
                JwtClaimTypes.NickName,
            })
            {
                Scopes = { "BeerlandApi" }
            }
        };
    
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientName = "Mvc Beerland Client",
                ClientId = "BeerlandClient",
                RequireClientSecret = false,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                AllowedScopes =
                {
                    "BeerlandApi",
                    // IdentityServerConstants.StandardScopes.Profile
                },
                AllowOfflineAccess = true,
            }
        };
}