namespace Gareon.WebService.Domain.Account
{
    public partial class ModuleVersion
    {
        public int NId { get; set; }
        public byte NDivisionId { get; set; }
        public byte NContentId { get; set; }
        public byte NModuleId { get; set; }
        public int NVersion { get; set; }
        public string SzVersion { get; set; }
        public string SzDesc { get; set; }
        public byte NValid { get; set; }
    }
}
