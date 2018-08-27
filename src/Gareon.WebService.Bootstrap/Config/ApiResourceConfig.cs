using System.Collections.Generic;
using Gareon.WebService.Constants;
using IdentityServer4.Models;

namespace Gareon.WebService.Bootstrap.Config
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