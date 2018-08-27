using System;

namespace Gareon.WebService.Domain
{
    public partial class ModuleVersionFile
    {
        public int NId { get; set; }
        public int NVersion { get; set; }
        public byte NDivisionId { get; set; }
        public byte NContentId { get; set; }
        public byte NModuleId { get; set; }
        public string SzFilename { get; set; }
        public string SzPath { get; set; }
        public int NFileSize { get; set; }
        public byte NFileType { get; set; }
        public int NFileTypeVersion { get; set; }
        public byte NToBePacked { get; set; }
        public DateTime TimeModified { get; set; }
        public byte NValid { get; set; }
    }
}
