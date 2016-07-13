using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace posv2_api.Entity
{
    public class MstTerm
    {
        public Int32 Id { get; set; }
        public String Term { get; set; }
        public Decimal NumberOfDays { get; set; }
    }
}