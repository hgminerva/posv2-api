using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Models
{
    public class PosMstTable
    {
        public Int32 Id { get; set; }
        public String TableCode { get; set; }
        public Int32 TableGroupId { get; set; }
        public String TableGroup { get; set; }
        public Int32 TopLocation { get; set; }
        public Int32 LeftLocation { get; set; }
    }
}