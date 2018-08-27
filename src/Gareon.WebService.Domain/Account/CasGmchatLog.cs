using System;

namespace Gareon.WebService.Domain.Account
{
    public partial class CasGmchatLog
    {
        public int NSerial { get; set; }
        public string SzGm { get; set; }
        public short WShardId { get; set; }
        public string SzCharName { get; set; }
        public int NCasSerial { get; set; }
        public string SzGmchatLog { get; set; }
        public DateTime DWritten { get; set; }
    }
}
