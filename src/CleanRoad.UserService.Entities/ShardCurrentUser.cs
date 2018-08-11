using System;

namespace CleanRoad.UserService.Entities
{
    public partial class ShardCurrentUser
    {
        public int NId { get; set; }
        public int NShardId { get; set; }
        public int NUserCount { get; set; }
        public DateTime DLogDate { get; set; }
    }
}
