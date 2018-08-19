using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gareon.UserService.Domain;

namespace Gareon.UserService.Logic.Abstractions.UsersSearchService
{
    public interface ITbUsersSearchService
    {
        Task<ICollection<TbUser>> FindAllAsync(Expression<Func<TbUser, bool>> predicate);
    }
}