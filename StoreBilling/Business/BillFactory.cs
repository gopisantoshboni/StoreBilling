using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreBilling.Models;
using StoreBilling.DAL;

namespace StoreBilling.Business
{
    public class BillFactory
    {
        public bool SaveBill(List<BillItems> BillItems, string Price, string GST, string TotalPrice)
        {
            Bill bill = new Bill();
            bill.Price = float.Parse(Price);
            bill.GST = float.Parse(GST);
            bill.TotalPrice = float.Parse(TotalPrice);

            BillData billData = new BillData();
            bill.BillNo = billData.SaveBill(bill);

            foreach(BillItems item in BillItems)
            {
                item.BillNo = bill.BillNo;
                BillItemsData billItemsData = new BillItemsData();
                billItemsData.SaveBillItems(item);
            }

            return true;
        }
    }
}