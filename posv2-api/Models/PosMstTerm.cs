using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Models
{
    public class PosMstTerm
    {
        public Int32 Id { get; set; }
        public String Term { get; set; }
        public Decimal NumberOfDays { get; set; }
    }
}