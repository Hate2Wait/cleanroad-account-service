using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gareon.WebService.Cqrs.Abstractions.Bus;
using Gareon.WebService.Cqrs.Abstractions.Commands;
using Gareon.WebService.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gareon.WebService.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class UniqueKillsController : Controller
    {
        private readonly ICommandBus bus;

        public UniqueKillsController(ICommandBus bus)
        {
            this.bus = bus;
        }

        [HttpGet("latestkills")]
        [AllowAnonymous]
        public async Task<IEnumerable<UniqueKillDto>> LatestKills()
        {
            var uniqueKills =
                await this.bus.SendAsync<UniqueKillsLoadCommand, IEnumerable<UniqueKillDto>>(
                    new UniqueKillsLoadCommand());

            uniqueKills = uniqueKills
                .OrderByDescending(kill => kill.KilledAt)
                .ThenBy(kill => kill.UniqueName)
                .ToArray();

            return uniqueKills;
        }
    }
}