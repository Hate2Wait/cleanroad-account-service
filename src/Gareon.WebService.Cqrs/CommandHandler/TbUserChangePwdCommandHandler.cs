using System;
using System.Threading;
using System.Threading.Tasks;
using Gareon.WebService.Cqrs.Abstractions.CommandHandler;
using Gareon.WebService.Cqrs.Abstractions.Commands;
using Gareon.WebService.Logic.Abstractions.Cryptography;
using Gareon.WebService.Repositories.Abstractions;
using MediatR;

namespace Gareon.WebService.Cqrs.CommandHandler
{
    public class TbUserChangePwdCommandHandler : IVoidCommandHandler<TbUserChangePwdCommand>
    {
        private readonly ITbUsersRepository tbUsersRepository;
        private readonly IHasher hasher;

        public TbUserChangePwdCommandHandler(ITbUsersRepository tbUsersRepository, IHasher hasher)
        {
            this.tbUsersRepository = tbUsersRepository;
            this.hasher = hasher;
        }

        public async Task<Unit> Handle(TbUserChangePwdCommand request, CancellationToken cancellationToken)
        {
            var user = await this.tbUsersRepository.FindAsync(request.Id);

            if (!this.hasher.ValidatePasswordEquality(request.CurrentPassword, user.Password))
            {
                throw new Exception("Current password not valid!");
            }
            
            if (!this.hasher.ValidatePasswordEquality(request.SecretCode, user.SecretCode, user.SecretCodeSalt))
            {
                throw new Exception("Current password not valid!");
            }

            user.Password = this.hasher.CreateMd5Hash(request.NewPassword);
            
            this.tbUsersRepository.Edit(user);

            await this.tbUsersRepository.EnsureChangesAsync();

            return Unit.Value;
        }
    }
}