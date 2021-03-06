﻿namespace Gareon.WebService.Domain.Account
{
    public partial class TrijobRanking
    {
        public int ShardId { get; set; }
        public byte TrijobType { get; set; }
        public byte RankType { get; set; }
        public byte Rank { get; set; }
        public string NickName { get; set; }
        public byte JobLevel { get; set; }
        public int JobData { get; set; }
        public byte IsNewEntry { get; set; }
        public short RankDelta { get; set; }
        public byte Country { get; set; }
    }
}
