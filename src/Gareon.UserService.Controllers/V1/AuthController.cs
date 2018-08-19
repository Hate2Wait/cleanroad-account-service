using System.Threading;
using System.Threading.Tasks;
using Gareon.UserService.Cqrs.Abstractions.Bus;
using Gareon.UserService.Cqrs.Abstractions.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Gareon.UserService.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly ICommandBus bus;

        public AuthController(ICommandBus bus)
        {
            this.bus = bus;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Register(CancellationToken cancellationToken, [FromBody] TbUserRegisterCommand registerCommand)
        {
            await this.bus.SendAsync<TbUserRegisterCommand>(registerCommand, cancellationToken);

            return this.NoContent();
        }
    }
}