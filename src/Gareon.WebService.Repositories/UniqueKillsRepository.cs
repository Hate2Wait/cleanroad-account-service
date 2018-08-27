using System.Collections.Generic;
using System.Threading.Tasks;
using Gareon.WebService.Domain;
using Gareon.WebService.Repositories.Abstractions;
using Gareon.WebService.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Gareon.WebService.Repositories
{
    public class UniqueKillsRepository : IUniqueKillsRepository
    {
        private readonly AccountServiceContext context;

        public UniqueKillsRepository(AccountServiceContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<UniqueKill>> GetAllAsync()
        {
            return await this.context.Set<UniqueKill>()
                .ToArrayAsync();
        }
    }
}