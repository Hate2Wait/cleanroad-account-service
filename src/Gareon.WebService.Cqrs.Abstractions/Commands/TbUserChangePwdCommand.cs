using Gareon.WebService.Cqrs.Abstractions.Base;

namespace Gareon.WebService.Cqrs.Abstractions.Commands
{
    public class TbUserChangePwdCommand : IVoidCommand
    {
        public int Id { get; }

        public string CurrentPassword { get; }

        public string NewPassword { get; }

        public string SecretCode { get; }

        public TbUserChangePwdCommand(int id, string currentPassword, string newPassword, string secretCode)
        {
            this.Id = id;
            this.CurrentPassword = currentPassword;
            this.NewPassword = newPassword;
            this.SecretCode = secretCode;
        }
    }
}