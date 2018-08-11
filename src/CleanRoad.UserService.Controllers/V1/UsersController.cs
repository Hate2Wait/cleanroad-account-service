using System.Threading;
using System.Threading.Tasks;
using CleanRoad.UserService.Cqrs.Abstractions.Bus;
using CleanRoad.UserService.Cqrs.Abstractions.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CleanRoad.UserService.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly ICommandBus bus;

        public UsersController(ICommandBus bus)
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