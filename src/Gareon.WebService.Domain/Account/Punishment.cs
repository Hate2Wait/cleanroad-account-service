using System;

namespace Gareon.WebService.Domain.Account
{
    public partial class Punishment
    {
        public int SerialNo { get; set; }
        public int UserJid { get; set; }
        public byte Type { get; set; }
        public string Executor { get; set; }
        public short Shard { get; set; }
        public string CharName { get; set; }
        public string CharInfo { get; set; }
        public string PosInfo { get; set; }
        public string Guide { get; set; }
        public string Description { get; set; }
        public DateTime RaiseTime { get; set; }
        public DateTime BlockStartTime { get; set; }
        public DateTime BlockEndTime { get; set; }
        public DateTime PunishTime { get; set; }
        public byte Status { get; set; }
    }
}
