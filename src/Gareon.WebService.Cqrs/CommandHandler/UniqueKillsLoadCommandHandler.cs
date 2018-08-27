using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gareon.WebService.Cqrs.Abstractions.CommandHandler;
using Gareon.WebService.Cqrs.Abstractions.Commands;
using Gareon.WebService.Presentation;
using Gareon.WebService.Repositories.Abstractions;

namespace Gareon.WebService.Cqrs.CommandHandler
{
    public class UniqueKillsLoadCommandHandler : ICommandHandler<UniqueKillsLoadCommand, IEnumerable<UniqueKillDto>>
    {
        private readonly IUniqueKillsRepository uniqueKillsRepository;
        private readonly IMapper mapper;

        public UniqueKillsLoadCommandHandler(IMapper mapper, IUniqueKillsRepository uniqueKillsRepository)
        {
            this.mapper = mapper;
            this.uniqueKillsRepository = uniqueKillsRepository;
        }

        public async Task<IEnumerable<UniqueKillDto>> Handle(UniqueKillsLoadCommand request, CancellationToken cancellationToken)
        {
            var uniqueKills = await this.uniqueKillsRepository.GetAllAsync();

            return this.mapper.Map<IEnumerable<UniqueKillDto>>(uniqueKills);
        }
    }
}