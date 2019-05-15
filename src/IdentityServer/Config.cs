// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
                new IdentityResources.Email(),
                new IdentityResource("roles","角色",new List<string> { JwtClaimTypes.Role })
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My API #1", new List<string> { "openid", "profile", "api1", "roles" })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // SPA client using implicit flow
                new Client
                {
                    ClientId = "spa",
                    ClientName = "SPA Client",
                    ClientUri = "http://localhost:8080",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    // AccessToken 是否可以通过浏览器返回
                    AllowAccessTokensViaBrowser = true,
                    // 是否需要用户点击同意（待测试）
                    RequireConsent = true,
                    // AccessToken 的有效期
                    AccessTokenLifetime = 60 * 5,

                    RedirectUris =
                    {
                        "http://localhost:8080/index.html",
                        "http://localhost:8080/callback.html",
                    },

                    // 登出 以后跳转的页面
                    PostLogoutRedirectUris = { "http://localhost:8080/" },
                    // vue 和 IdentityServer 不在一个域上，需要指定跨域
                    AllowedCorsOrigins = { "http://localhost:8080" },

                    AllowedScopes = { "openid", "profile", "api1", "roles" }
                }
            };
        }
    }
}