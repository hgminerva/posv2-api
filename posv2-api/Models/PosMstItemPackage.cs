using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Models
{
    public class PosMstItemPackage
    {
        public Int32 Id { get; set; }
        public Int32 ItemId { get; set; }
        public Int32 PackageItemId { get; set; }
        public Int32 UnitId { get; set; }
        public Decimal Quantity { get; set; }
        public Boolean IsOptional { get; set; }
    }
}