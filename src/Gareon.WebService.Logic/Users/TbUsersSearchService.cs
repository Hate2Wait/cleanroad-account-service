using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gareon.WebService.Domain;
using Gareon.WebService.Logic.Abstractions.UsersSearchService;
using Gareon.WebService.Repositories.Abstractions;

namespace Gareon.WebService.Logic.Users
{
    public class TbUsersSearchService : ITbUsersSearchService
    {
        private readonly ITbUsersRepository usersRepository;

        public TbUsersSearchService(ITbUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<ICollection<TbUser>> FindAllAsync(Expression<Func<TbUser, bool>> predicate)
        {
            var users = await this.usersRepository
                .LoadAllAsync();

            return users
                .AsQueryable()
                .Where(predicate)
                .ToArray();
        }
    }
}