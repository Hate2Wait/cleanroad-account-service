using System;

namespace Gareon.WebService.Domain.Account
{
    public partial class TbUser
    {
        public int Jid { get; set; }
        public string StrUserId { get; set; }
        public string Password { get; set; }
        public byte? Status { get; set; }
        public byte? Gmrank { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string CertificateNum { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTime? Regtime { get; set; }
        public string RegIp { get; set; }
        public DateTime? TimeLog { get; set; }
        public int? Freetime { get; set; }
        public byte SecPrimary { get; set; }
        public byte SecContent { get; set; }
        public int AccPlayTime { get; set; }
        public int LatestUpdateTimeToPlayTime { get; set; }
        public int Play123Time { get; set; }
        public string SecretCode { get; set; }
        public byte[] SecretCodeSalt { get; set; }
    }
}
