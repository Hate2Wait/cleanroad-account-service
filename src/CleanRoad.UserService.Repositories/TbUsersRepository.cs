using System.Linq;
using System.Threading.Tasks;
using CleanRoad.UserService.Entities;
using CleanRoad.UserService.Repositories.Abstractions;
using CleanRoad.UserService.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanRoad.UserService.Repositories
{
    public class TbUsersRepository : ITbUsersRepository
    {
        private readonly UserServiceContext context;

        public TbUsersRepository(UserServiceContext context)
        {
            this.context = context;
        }

        public async Task<TbUser> FindAsync(int jid)
        {
            return await this.context.Set<TbUser>()
                .AsQueryable()
                .FirstOrDefaultAsync(user => user.Jid == jid);
        }
        
        public async Task<TbUser> FindAsync(string userName)
        {
            return await this.context.Set<TbUser>()
                .AsQueryable()
                .FirstOrDefaultAsync(user => user.StrUserId == userName);
        }

        public async Task AddAsync(TbUser user)
        {
            await this.context.AddAsync(user);
        }

        public void Edit(TbUser user)
        {
            var entry = this.context.Entry(user);
            entry.State = EntityState.Modified;
        }

        public void EnsureChanges()
        {
            this.context.SaveChanges();
        }

        public async Task EnsureChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}