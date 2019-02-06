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
                new IdentityResources.Profile()
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
                        "https://localhost:44307/signin-oidc"
                    },
                    
                    AllowedScopes =
                    {
                        OidcConstants.StandardScopes.OpenId
                    },
                    AllowedGrantTypes =
                    {
                        OidcConstants.GrantTypes.Implicit,
                        OidcConstants.GrantTypes.ClientCredentials
                    }
                }
            };
        }
    }
}
