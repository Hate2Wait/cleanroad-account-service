using System;

namespace Gareon.WebService.Domain.Account
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
