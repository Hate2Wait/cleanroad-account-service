using System.Collections.Generic;
using Gareon.UserService.Constants;
using IdentityServer4.Models;

namespace Gareon.UserService.Bootstrap.Config
{
    public class ApiResourceConfig
    {
        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>
            {
                new ApiResource(ServiceNames.UserService),
            };
        }
    }
}