using System;

namespace Gareon.WebService.Domain
{
    public partial class OldBlockedUser
    {
        public int UserJid { get; set; }
        public byte Type { get; set; }
        public int SerialNo { get; set; }
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}
