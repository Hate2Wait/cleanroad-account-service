using System.Collections.Generic;
using System.Threading.Tasks;
using Gareon.WebService.Domain;
using Gareon.WebService.Domain.Account;

namespace Gareon.WebService.Repositories.Abstractions
{
    public interface IUniqueKillsRepository
    {
        Task<ICollection<UniqueKill>> GetAllAsync();
    }
}