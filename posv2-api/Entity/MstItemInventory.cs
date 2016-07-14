using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace posv2_api.Entity
{
    public class MstItemInventory
    {
        public Int32 Id { get; set; }
        public Int32 ItemId { get; set; }
        public DateTime? InventoryDate { get; set; }
        public Decimal Quantity { get; set; }
    }
}