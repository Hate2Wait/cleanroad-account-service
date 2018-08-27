namespace Gareon.WebService.Domain
{
    public partial class Shard
    {
        public short NId { get; set; }
        public byte NFarmId { get; set; }
        public byte NContentId { get; set; }
        public string SzName { get; set; }
        public string SzDesc { get; set; }
        public string SzDbconfig { get; set; }
        public short NMaxUser { get; set; }
        public short NStartupServerId { get; set; }
        public byte NStatus { get; set; }
        public byte NCurrentUserRatio { get; set; }
    }
}
