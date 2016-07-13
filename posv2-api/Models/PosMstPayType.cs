using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace posv2_api.Models
{
    public class PosMstPayType
    {
        public Int32 Id { get; set; }
        public String PayType { get; set; }
        public Int32 AccountId { get; set; }
    }
}