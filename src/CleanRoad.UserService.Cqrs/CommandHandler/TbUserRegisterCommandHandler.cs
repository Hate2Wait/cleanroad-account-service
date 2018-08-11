using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanRoad.UserService.Cqrs.Abstractions.Commands;
using CleanRoad.UserService.Cqrs.Abstractions.CommandHandler;
using CleanRoad.UserService.Entities;
using CleanRoad.UserService.Logic.Abstractions.Cryptography;
using CleanRoad.UserService.Repositories.Abstractions;
using MediatR;

namespace CleanRoad.UserService.Cqrs.CommandHandler
{
    public class TbUserRegisterCommandHandler : IVoidCommandHandler<TbUserRegisterCommand>
    {
        private readonly ITbUsersRepository tbUsersRepository;
        private readonly IHasher hasher;

        public TbUserRegisterCommandHandler(ITbUsersRepository tbUsersRepository, IHasher hasher)
        {
            this.tbUsersRepository = tbUsersRepository;
            this.hasher = hasher;
        }
        
        public async Task<Unit> Handle(TbUserRegisterCommand command, CancellationToken ctx)
        {
            var tbUser = new TbUser
            {
                StrUserId = command.UserName,
                Name = command.Name,
                Password = this.hasher.CreateHash(command.Password),
                Email = command.EmailAddress,
                SecContent = 1,
                SecPrimary = 1,
                Gmrank = 1
            };

            await this.tbUsersRepository.AddAsync(tbUser);
            
            await this.tbUsersRepository.EnsureChangesAsync();
            
            return Unit.Value;
        }
    }
}