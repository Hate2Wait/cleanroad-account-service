using System.Net;
using Gareon.UserService.Cqrs.Abstractions.Base;

namespace Gareon.UserService.Cqrs.Abstractions.Commands
{
    public class TbUserRegisterCommand : IVoidCommand
    {
        public string UserName { get; }

        public string Password { get; }

        public string Email { get; }

        public string Name { get;  }

        public string SecretCode { get; }

        public IPAddress IpAddress { get; }

        public TbUserRegisterCommand(string userName, string password, string email, string name, string secretCode, IPAddress ipAddress)
        {
            this.UserName = userName;
            this.Password = password;
            this.Email = email;
            this.Name = name;
            this.SecretCode = secretCode;
            this.IpAddress = ipAddress;
        }
    }
}