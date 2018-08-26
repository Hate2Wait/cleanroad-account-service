using System.Collections.Generic;
using System.Threading.Tasks;
using Gareon.UserService.Domain;

namespace Gareon.UserService.Repositories.Abstractions
{
    public interface IBlockedUsersRepository
    {
        Task<ICollection<BlockedUser>> FindAllAsync();
    }
}