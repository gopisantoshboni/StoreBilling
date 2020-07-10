using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBilling.Models
{
    public class BillItems
    {
        public int BillNo { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public float ItemPrice { get; set; }
        public float Discount { get; set; }
        public float TotalPrice { get; set; }
    }
}