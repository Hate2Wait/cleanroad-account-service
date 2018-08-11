using System;

namespace CleanRoad.UserService.Entities
{
    public partial class Notice
    {
        public int Id { get; set; }
        public byte ContentId { get; set; }
        public string Subject { get; set; }
        public string Article { get; set; }
        public DateTime EditDate { get; set; }
    }
}
