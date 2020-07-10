using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBilling.Models
{
    public class Bill
    {
        public int BillNo { get; set; }
        public float Price { get; set; }
        public float GST { get; set; }
        public float TotalPrice { get; set; }
    }
}