using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Models
{
    public class PosMstItemPrice
    {
        public Int32 Id { get; set; }
        public Int32 ItemId { get; set; }
        public String PriceDescription { get; set; }
        public Decimal Price { get; set; }
        public Decimal TriggerQuantity { get; set; }
    }
}