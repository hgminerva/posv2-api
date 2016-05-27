using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Entity
{
    public class MstTableGroup
    {
        public Int32 Id { get; set; }
        public String TableGroup { get; set; }
        public Int32 EntryUserId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public Boolean IsLocked { get; set; }

        // FK
        public virtual ICollection<MstTable> MstTables { get; set; }

        // Method
        public MstTableGroup()
        {
            this.MstTables = new HashSet<MstTable>();
        }
    }
}