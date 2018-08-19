using System;

namespace Gareon.UserService.Domain
{
    public partial class SkCharRenameLog
    {
        public int Id { get; set; }
        public int? Jid { get; set; }
        public string Struserid { get; set; }
        public string OldChar { get; set; }
        public string NewChar { get; set; }
        public string Server { get; set; }
        public DateTime? Timechange { get; set; }
    }
}
