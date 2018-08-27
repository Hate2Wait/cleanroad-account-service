using System;

namespace Gareon.WebService.Domain
{
    public partial class ShardCurrentUser
    {
        public int NId { get; set; }
        public int NShardId { get; set; }
        public int NUserCount { get; set; }
        public DateTime DLogDate { get; set; }
    }
}
