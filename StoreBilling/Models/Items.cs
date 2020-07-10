using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace StoreBilling.Models
{
    public class Items
    {
        public int ItemId { get; set; }
        public string Name { get; set; }      
        public int ItemTypeId { get; set; }
        public float Price { get; set; }

        public ItemType ItemType { get; set; }
    }

   
}