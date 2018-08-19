using Gareon.UserService.Cqrs.Abstractions.Base;

namespace Gareon.UserService.Cqrs.Abstractions.Commands
{
    public class TbUserRegisterCommand : IVoidCommand
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}