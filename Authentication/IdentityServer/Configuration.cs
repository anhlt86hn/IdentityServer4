﻿using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            { 
                new IdentityResources.OpenId(),
                //new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "rc.scope",
                    UserClaims =
                    {
                        "rc.grandma"
                    }
                }
            };

        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource>
            {
                new ApiResource("ApiOne"),
                new ApiResource("ApiTwo", new string[] { "rc.api.grandma" })
            };
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "ApiOne" }
                },

                new Client
                {
                    ClientId = "client_id_mvc",
                    ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:44321/signin-oidc" }, // MvcClient
                    AllowedScopes = { 
                        "ApiOne", 
                        "ApiTwo",
                    IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                    //IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                    "rc.scope"
                    },

                    // put all the claims in this id token
                    // AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,
                    RequireConsent = false,
                },
                new Client
                {
                    ClientId = "client_id_js",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = {
                        "https://localhost:44386/signin"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "ApiOne"
                    }
                }
            };
    }
}
