using System.Collections.Generic;
using System.Threading.Tasks;
using Gareon.WebService.Domain;
using Gareon.WebService.Repositories.Abstractions;
using Gareon.WebService.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Gareon.WebService.Repositories
{
    public class BlockedUsersRepository : IBlockedUsersRepository
    {
        private readonly UserServiceContext context;

        public BlockedUsersRepository(UserServiceContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<BlockedUser>> GetAllAsync()
        {
            return await this.context.Set<BlockedUser>()
                .AsNoTracking()
                .ToArrayAsync();
        }
    }
}