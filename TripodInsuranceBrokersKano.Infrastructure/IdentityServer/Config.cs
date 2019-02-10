using System;
using System.Collections.Generic;
using System.Text;
using IdentityModel;
using IdentityServer4.Models;

namespace TripodInsuranceBrokersKano.Infrastructure.IdentityServer
{
    public static class Config
    {
        public static ApiResource GetApiResource()
        {
            return new ApiResource();
        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("roles", new List<string>(){ "roles" })
            };
        }

        public static List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientName = "Tripod Office Manager",
                    ClientId = "TripodOMApp",
                    RedirectUris =
                    {
                        "https://localhost:44393/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:44393/signout-callback-oidc"
                    },
                    AllowOfflineAccess = true,
                    RequireConsent = false, //temporary setting for development change to true in production
                    AllowedScopes =
                    {
                        OidcConstants.StandardScopes.OpenId,
                        OidcConstants.StandardScopes.Profile,
                        OidcConstants.StandardScopes.Email,
                        "roles",
                        "tripodinsurancebrokersapi"
                    },
                    AllowedGrantTypes =
                    {
                        OidcConstants.GrantTypes.Implicit,
                        OidcConstants.GrantTypes.ClientCredentials
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("tripodinsurancebrokersapi", 
                    "Tripod Kano Applications Api")
            };
        }
    }
}
