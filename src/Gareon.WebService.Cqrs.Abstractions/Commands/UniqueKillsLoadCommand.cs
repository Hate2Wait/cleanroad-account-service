using System.Collections.Generic;
using Gareon.WebService.Cqrs.Abstractions.Base;
using Gareon.WebService.Presentation;

namespace Gareon.WebService.Cqrs.Abstractions.Commands
{
    public class UniqueKillsLoadCommand : ICommand<IEnumerable<UniqueKillDto>>
    {
        
    }
}