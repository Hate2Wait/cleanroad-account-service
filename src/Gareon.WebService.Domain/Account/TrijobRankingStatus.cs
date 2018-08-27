using System;

namespace Gareon.WebService.Domain.Account
{
    public partial class TrijobRankingStatus
    {
        public int ShardId { get; set; }
        public byte Status { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
