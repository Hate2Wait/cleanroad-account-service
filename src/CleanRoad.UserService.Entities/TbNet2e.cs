using System;

namespace CleanRoad.UserService.Entities
{
    public partial class TbNet2e
    {
        public int Jid { get; set; }
        public string StrUserId { get; set; }
        public string Password { get; set; }
        public string SecondPassword { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public byte? Status { get; set; }
        public byte? Gmrank { get; set; }
        public string Name { get; set; }
        public string Mdk { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string CertificateNum { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Cid { get; set; }
        public int? CidType { get; set; }
        public DateTime? Regtime { get; set; }
        public string RegIp { get; set; }
        public DateTime? TimeLog { get; set; }
        public int? Freetime { get; set; }
        public byte SecPrimary { get; set; }
        public byte SecContent { get; set; }
        public DateTime? Birthday { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string WherePlay { get; set; }
        public string WhereKnow { get; set; }
        public string Reference { get; set; }
        public string Games { get; set; }
        public string StrLevel { get; set; }
        public string Class { get; set; }
        public byte? HowPlay { get; set; }
        public string Inviter { get; set; }
        public string SecAct { get; set; }
        public DateTime? LastModification { get; set; }
    }
}
