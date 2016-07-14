﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Models
{
    public class PosTrnDebitCreditMemo
    {
        public Int32 Id { get; set; }
        public Int32 PeriodId { get; set; }
        public String DCMemoNumber { get; set; }
        public DateTime? DCMemoDate { get; set; }
        public String Particulars { get; set; }
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