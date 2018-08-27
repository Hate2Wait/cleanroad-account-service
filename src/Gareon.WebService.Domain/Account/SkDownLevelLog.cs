using System;

namespace Gareon.WebService.Domain.Account
{
    public partial class SkDownLevelLog
    {
        public int Id { get; set; }
        public int? Jid { get; set; }
        public string Struserid { get; set; }
        public string Charname { get; set; }
        public string Package { get; set; }
        public string Newlevel { get; set; }
        public string Server { get; set; }
        public DateTime? Timedown { get; set; }
    }
}
