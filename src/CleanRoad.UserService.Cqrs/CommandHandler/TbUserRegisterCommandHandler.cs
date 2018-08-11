using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanRoad.UserService.Cqrs.Abstractions.Commands;
using CleanRoad.UserService.Cqrs.Abstractions.CommandHandler;
using CleanRoad.UserService.Entities;
using CleanRoad.UserService.Repositories.Abstractions;
using MediatR;

namespace CleanRoad.UserService.Cqrs.CommandHandler
{
    public class TbUserRegisterCommandHandler : IVoidCommandHandler<TbUserRegisterCommand>
    {
        private readonly ITbUsersRepository tbUsersRepository;

        public TbUserRegisterCommandHandler(ITbUsersRepository tbUsersRepository)
        {
            this.tbUsersRepository = tbUsersRepository;
        }
        
        public async Task<Unit> Handle(TbUserRegisterCommand command, CancellationToken ctx)
        {
            var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(command.Password));
            
            var tbUser = new TbUser
            {
                StrUserId = command.UserName,
                Password = Encoding.UTF8.GetString(hash),
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