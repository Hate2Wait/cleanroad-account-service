using System;

namespace CleanRoad.UserService.Entities
{
    public partial class QuaySoEpoint
    {
        public int Id { get; set; }
        public string UserCash { get; set; }
        public int? Server { get; set; }
        public int? CharId { get; set; }
        public string CharName { get; set; }
        public int? SpOwn { get; set; }
        public int? SpBefore { get; set; }
        public int? SpAfter { get; set; }
        public DateTime? Regdate { get; set; }
        public string SourcePoint { get; set; }
    }
}
