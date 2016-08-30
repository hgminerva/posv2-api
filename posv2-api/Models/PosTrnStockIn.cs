﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Models
{
    public class PosTrnStockIn
    {
        public Int32 Id { get; set; }
        public Int32 PeriodId { get; set; }
        public DateTime? StockInDate { get; set; }
        public String StockInNumber { get; set; }
        public Int32 SupplierId { get; set; }
        public String Remarks { get; set; }
        public Boolean IsReturn { get; set; }
        public Int32? CollectionId { get; set; }
        public Int32? PurchaseOrderId { get; set; }
        public Int32? SalesId { get; set; }
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