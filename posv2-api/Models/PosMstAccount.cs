using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Models
{
    public class PosMstAccount
    {
        public Int32 Id { get; set; }
        public String Code { get; set; }
        public String Account { get; set; }
        public Boolean IsLocked { get; set; }
        public String AccountType { get; set; }
    }
}