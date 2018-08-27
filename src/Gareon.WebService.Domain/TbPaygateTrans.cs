using System;

namespace Gareon.WebService.Domain
{
    public partial class TbPaygateTrans
    {
        public int TransId { get; set; }
        public DateTime? TransDate { get; set; }
        public string TransType { get; set; }
        public string BankId { get; set; }
        public string AccountId { get; set; }
        public string OrderNo { get; set; }
        public int? MoneyValue { get; set; }
        public int? BeforeMoney { get; set; }
        public int? AfterMoney { get; set; }
        public long? PgTransId { get; set; }
    }
}
