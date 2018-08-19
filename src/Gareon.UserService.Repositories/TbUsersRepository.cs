using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gareon.UserService.Domain;
using Gareon.UserService.Repositories.Abstractions;
using Gareon.UserService.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Gareon.UserService.Repositories
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

        public async Task<TbUser> FindUserByUserNameOrEmailAsync(string emailOrUserName)
        {
            return await this.context.Set<TbUser>()
                .AsQueryable()
                .FirstOrDefaultAsync(user => user.Email == emailOrUserName || user.StrUserId == emailOrUserName);
        }

        public async Task<ICollection<TbUser>> LoadAllAsync()
        {
            return await this.context.Set<TbUser>()
                .ToArrayAsync();
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