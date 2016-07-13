using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Models
{
    public class PosMstDiscountItem
    {
        public Int32 Id { get; set; }
        public Int32 DiscountId { get; set; }
        public Int32 ItemId { get; set; }
    }
}