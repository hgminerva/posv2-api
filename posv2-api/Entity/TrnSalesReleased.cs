using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace posv2_api.Entity
{
    public class TrnSalesReleased
    {
        public Int32 Id { get; set; }
        public String SalesNumber { get; set; }
        public String ItemCode { get; set; }
        public Int32 ItemId { get; set; }
        public Decimal Quantity { get; set; }
        public Int32 EntryUserId { get; set; }
        public String EntryDateTime { get; set; }

    }
}