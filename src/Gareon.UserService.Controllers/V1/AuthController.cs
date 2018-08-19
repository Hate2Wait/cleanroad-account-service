using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gareon.UserService.Cqrs.Abstractions.Bus;
using Gareon.UserService.Cqrs.Abstractions.Commands;
using Gareon.UserService.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gareon.UserService.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly ICommandBus bus;
        private readonly IMapper mapper;

        public AuthController(ICommandBus bus, IMapper mapper)
        {
            this.bus = bus;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<IActionResult> Register(CancellationToken cancellationToken, [FromBody] TbUserRegisterDto registerDto)
        {
            var registerCommand = this.mapper.Map<TbUserRegisterCommand>(registerDto);
            
            await this.bus.SendAsync(registerCommand, cancellationToken);

            return this.NoContent();
        }
    }
}