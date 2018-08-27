using System.Threading;
using System.Threading.Tasks;
using Gareon.WebService.Cqrs.Abstractions.CommandHandler;
using Gareon.WebService.Cqrs.Abstractions.Commands;
using Gareon.WebService.Domain;
using Gareon.WebService.Logic.Abstractions.Cryptography;
using Gareon.WebService.Repositories.Abstractions;
using MediatR;

namespace Gareon.WebService.Cqrs.CommandHandler
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
            var salt = this.hasher.GenerateSalt();
            
            var tbUser = new TbUser
            {
                StrUserId = command.UserName,
                Name = command.Name,
                Password = this.hasher.CreateMd5Hash(command.Password),
                SecretCode = this.hasher.CreateSaltedHash(command.SecretCode, salt),
                SecretCodeSalt = salt,
                Email = command.Email,
                RegIp = command.IpAddress.ToString()
            };

            await this.tbUsersRepository.AddAsync(tbUser);
            
            await this.tbUsersRepository.EnsureChangesAsync();
            
            return Unit.Value;
        }
    }
}