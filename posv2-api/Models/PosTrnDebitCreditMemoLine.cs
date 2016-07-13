using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Models
{
    public class PosTrnDebitCreditMemoLine
    {
        public Int32 Id { get; set; }
        public Int32 DCMemoId { get; set; }
        public Int32? SalesId { get; set; }
        public Int32 AccountId { get; set; }
        public String Particulars { get; set; }
        public Decimal DebitAmount { get; set; }
        public Decimal CreditAmount { get; set; }
    }
}