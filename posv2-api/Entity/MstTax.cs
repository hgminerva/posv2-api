using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace posv2_api.Entity
{
    public class MstTax
    {
        public Int32 Id { get; set; }
        public String Code { get; set; }
        public String Tax { get; set; }
        public Decimal Rate { get; set; }
        public Int32 AccountId { get; set; }

    }
}