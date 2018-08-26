namespace Gareon.UserService.Presentation
{
    public class TbUserChangePwdDto
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string SecretCode { get; set; }
    }
}