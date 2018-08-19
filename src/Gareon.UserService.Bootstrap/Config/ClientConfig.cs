using System.Collections.Generic;
using Gareon.UserService.Constants;
using IdentityServer4;
using IdentityServer4.Models;

namespace Gareon.UserService.Bootstrap.Config
{
    public class ClientConfig
    {
        public static IEnumerable<Client> GetClients(string clientId, string clientSecrect, string[] allowedOrigins)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = clientId,

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret(clientSecrect.Sha256())
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        ServiceNames.UserService,
                    },

                    AllowedCorsOrigins = allowedOrigins,

                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 60 * 60 * 24 * 7,
                    AlwaysSendClientClaims = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                }
            };
        }
    }
}