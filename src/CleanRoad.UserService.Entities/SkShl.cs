using System;

namespace CleanRoad.UserService.Entities
{
    public partial class SkShl
    {
        public int Idx { get; set; }
        public int Jid { get; set; }
        public int Cos { get; set; }
        public int Cgs { get; set; }
        public int Hos { get; set; }
        public int Hgs { get; set; }
        public DateTime EventTime { get; set; }
    }
}
