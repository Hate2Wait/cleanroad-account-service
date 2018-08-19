using System.Collections.Generic;
using System.Threading.Tasks;
using Gareon.UserService.Domain;
using Gareon.UserService.Repositories.Abstractions;
using Gareon.UserService.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Gareon.UserService.Repositories
{
    public class BlockedUsersRepository : IBlockedUsersRepository
    {
        private readonly UserServiceContext context;

        public BlockedUsersRepository(UserServiceContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<BlockedUser>> FindAllBlockedUsersAsync()
        {
            return await this.context.Set<BlockedUser>()
                .AsNoTracking()
                .ToArrayAsync();
        }
    }
}