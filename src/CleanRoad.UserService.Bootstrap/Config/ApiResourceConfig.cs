using System.Collections.Generic;
using CleanRoad.UserService.Constants;
using IdentityServer4.Models;

namespace CleanRoad.UserService.Bootstrap.Config
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