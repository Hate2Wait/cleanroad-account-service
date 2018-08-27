using System.Collections.Generic;
using System.Threading.Tasks;
using Gareon.WebService.Domain;

namespace Gareon.WebService.Repositories.Abstractions
{
    public interface ITbUsersRepository
    {
        Task<TbUser> FindAsync(int jid);

        Task<TbUser> FindAsync(string userName);

        Task<TbUser> FindUserByUserNameOrEmailAsync(string emailOrUserName);

        Task<ICollection<TbUser>> LoadAllAsync(); 
        
        Task AddAsync(TbUser user);

        void Edit(TbUser user);

        void EnsureChanges();

        Task EnsureChangesAsync();
    }
}