// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Auth.UI
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("ApiGateway", "Api Gateway"),
                new ApiResource("UserManager", "User Manager")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // Admin Portal
                new Client
                {
                    ClientId = "AdminPortal",
                    ClientName = "Admin Portal",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =           { "http://localhost:5110/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:5110/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:5110" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ApiGateway",
                        "UserManager"
                    }
                }
            };
        }
    }
}