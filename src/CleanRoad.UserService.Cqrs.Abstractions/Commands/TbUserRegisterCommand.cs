using CleanRoad.UserService.Cqrs.Abstractions.Base;

namespace CleanRoad.UserService.Cqrs.Abstractions.Commands
{
    public class TbUserRegisterCommand : IVoidCommand
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string Name { get; set; }
    }
}