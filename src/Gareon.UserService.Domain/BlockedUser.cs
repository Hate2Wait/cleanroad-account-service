using System;

namespace Gareon.UserService.Domain
{
    public partial class BlockedUser
    {
        public int UserJid { get; set; }
        public string UserId { get; set; }
        public byte Type { get; set; }
        public int SerialNo { get; set; }
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}
