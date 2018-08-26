using System.Linq;
using Gareon.ServiceBase.Logic.Abstractions.Services;
using IdentityModel;
using Microsoft.AspNetCore.Http;

namespace Gareon.ServiceBase.Logic.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ApplicationUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public int Id => this.GetUserId();
        public string UserName => this.GetUserName();


        private int GetUserId()
        {
            var subject = this.httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim =>
                claim.Type == JwtClaimTypes.Subject);

            int.TryParse(subject?.Value, out var id);

            return id;
        }

        private string GetUserName()
        {
            var preferredUserName  = this.httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim =>
                claim.Type == JwtClaimTypes.PreferredUserName);

            return preferredUserName?.Value ?? string.Empty;
        }
    }
}