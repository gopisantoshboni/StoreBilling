using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreBilling.Models;
using StoreBilling.Business;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace StoreBilling.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            NameValuePair nameValuePair = new NameValuePair();
            NameValuePairFactory nameValuePairFactory = new NameValuePairFactory();

            nameValuePair = nameValuePairFactory.GetValue("GST");
            ViewBag.GST = nameValuePair.Value;
            return View(nameValuePair);
        }

        public JsonResult ListItemsByKeyword(string SearchedString)
        {
            List<Items> itemsList = new List<Items>();
            
            ItemFactory itemFactory = new ItemFactory();

            List<Items> removedItemsList = new List<Items>();

            itemsList = itemFactory.GetItemsOnSearch(SearchedString);
           
            return Json(itemsList, JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult ReadItemDetailsById(string ItemId)
        {
            Items items = new Items(); 
            ItemFactory itemFactory = new ItemFactory();

            items = itemFactory.GetItemById(Convert.ToInt32(ItemId));

            return Json(items, JsonRequestBehavior.AllowGet);

        }

        public JsonResult SaveBill(List<BillItems> BillItems,string Price,string GST,string TotalPrice)
        {
            bool saved = false;
            BillFactory billFactory = new BillFactory();
            saved = billFactory.SaveBill(BillItems, Price, GST, TotalPrice);
            return Json(saved);
        }
    }
}