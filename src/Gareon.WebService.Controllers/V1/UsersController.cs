using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gareon.WebService.Constants;
using Gareon.WebService.Cqrs.Abstractions.Bus;
using Gareon.WebService.Cqrs.Abstractions.Commands;
using Gareon.WebService.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gareon.WebService.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly ICommandBus bus;
        private readonly IMapper mapper;

        public UsersController(ICommandBus bus, IMapper mapper)
        {
            this.bus = bus;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.GameMaster)]
        public async Task<IEnumerable<TbUserDto>> LoadUsers()
        {
            var users = await this.bus.SendAsync<TbUsersLoadCommand, TbUserDto[]>(new TbUsersLoadCommand());

            return users;
        }

        [Authorize]
        [HttpPatch("{id:int}/passwordchange")]
        public async Task<IActionResult> Passwordchange(int id, [FromBody] TbUserChangePwdDto userChangePwdDto)
        {
            var command = new TbUserChangePwdCommand(id, userChangePwdDto.CurrentPassword, userChangePwdDto.NewPassword, userChangePwdDto.SecretCode);

            await this.bus.SendAsync(command);

            return this.NoContent();
        }
    }
}