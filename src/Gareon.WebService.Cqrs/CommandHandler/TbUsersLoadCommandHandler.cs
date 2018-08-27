using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gareon.WebService.Cqrs.Abstractions.CommandHandler;
using Gareon.WebService.Cqrs.Abstractions.Commands;
using Gareon.WebService.Presentation;
using Gareon.WebService.Repositories.Abstractions;

namespace Gareon.WebService.Cqrs.CommandHandler
{
    public class TbUsersLoadCommandHandler : ICommandHandler<TbUsersLoadCommand, TbUserDto[]>
    {
        private readonly ITbUsersRepository tbUsersRepository;
        private readonly IBlockedUsersRepository blockedUsersRepository;
        private readonly IMapper mapper;

        public TbUsersLoadCommandHandler(IBlockedUsersRepository blockedUsersRepository, ITbUsersRepository tbUsersRepository, IMapper mapper)
        {
            this.blockedUsersRepository = blockedUsersRepository;
            this.tbUsersRepository = tbUsersRepository;
            this.mapper = mapper;
        }

        public async Task<TbUserDto[]> Handle(TbUsersLoadCommand request, CancellationToken cancellationToken)
        {
            var users = await this.tbUsersRepository
                .LoadAllAsync();

            var blockedUsers = await this.blockedUsersRepository.GetAllAsync();

            var mappedUsers = this.mapper.Map<ICollection<TbUserDto>>(users);

            return mappedUsers
                .Select(user =>
                {
                    var blockedUser = blockedUsers.FirstOrDefault(blocked => blocked.UserJid == user.Id && blocked.TimeEnd > DateTime.UtcNow);

                    if (blockedUser == null)
                    {
                        return user;
                    }

                    user.IsBlocked = true;
                    user.BlockedUntil = blockedUser.TimeEnd;

                    return user;
                })
                .ToArray();
        }
    }
}