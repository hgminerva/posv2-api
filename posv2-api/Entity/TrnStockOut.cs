using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace posv2_api.Entity
{
    public class TrnStockOut
    {
        public Int32 Id { get; set; }
        public Int32 PeriodId { get; set; }
        public DateTime? StockOutDate { get; set; }
        public String StockOutNumber { get; set; }
        public Int32 AccountId { get; set; }
        public String Remarks { get; set; }
        public Int32 PreparedBy { get; set; }
        public Int32 CheckedBy { get; set; }
        public Int32 ApprovedBy { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 EntryUserId { get; set; }
        public DateTime? EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}