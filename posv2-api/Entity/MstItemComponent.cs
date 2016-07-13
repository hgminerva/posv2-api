﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace posv2_api.Entity
{
    public class MstItemComponent
    {
        public Int32 Id { get; set; }
        public Int32 ItemId { get; set; }
        public Int32 ComponentItemId { get; set; }
        public Int32 UnitId { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
        public Boolean IsPrinted { get; set; }
    }
}