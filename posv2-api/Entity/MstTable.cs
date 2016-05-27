using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace posv2_api.Entity
{
    public class MstTable
    {
        public Int32 Id { get; set; }
        public String TableCode { get; set; }
        public Int32 TableGroupId { get; set; }
        [ForeignKey("TableGroupId")]
        public virtual MstTableGroup MstTableGroup { get; set; }
        public Int32 TopLocation { get; set; }
        public Int32 LeftLocation { get; set; }
    }
}