using System.Collections.Generic;
using System.Threading.Tasks;
using Gareon.WebService.Domain;

namespace Gareon.WebService.Repositories.Abstractions
{
    public interface IBlockedUsersRepository
    {
        Task<ICollection<BlockedUser>> GetAllAsync();
    }
}