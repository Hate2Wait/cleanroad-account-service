using System.Threading.Tasks;
using CleanRoad.UserService.Entities;

namespace CleanRoad.UserService.Repositories.Abstractions
{
    public interface ITbUsersRepository
    {
        Task<TbUser> FindAsync(int jid);

        Task<TbUser> FindAsync(string userName);

        Task AddAsync(TbUser user);

        void Edit(TbUser user);

        void EnsureChanges();

        Task EnsureChangesAsync();
    }
}