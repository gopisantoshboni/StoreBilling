using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBilling.Models
{
    public class ItemType
    {
        public int ItemTypeId { get; set; }
        public string Name { get; set; }
        public float discount { get; set; }
    }
}