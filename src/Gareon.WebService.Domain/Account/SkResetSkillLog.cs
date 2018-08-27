using System;

namespace Gareon.WebService.Domain.Account
{
    public partial class SkResetSkillLog
    {
        public int Id { get; set; }
        public int? Jid { get; set; }
        public string Struserid { get; set; }
        public string Charname { get; set; }
        public string SkillDown { get; set; }
        public string NewSkill { get; set; }
        public string SilkDown { get; set; }
        public string Server { get; set; }
        public DateTime? TimeReset { get; set; }
    }
}
