using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreBilling.Models;
using StoreBilling.DAL;

namespace StoreBilling.Business
{
    public class ItemFactory
    {
        public List<Items> GetItemsOnSearch(string SearchedString)
        {
            List<Items> itemsList = new List<Items>();
            ItemData itemData = new ItemData();

            itemsList = itemData.GetItemsOnSearch(SearchedString);

            return itemsList;
        }

        public Items GetItemById(int ItemId)
        {
            Items items = new Items();
            ItemData itemData = new ItemData();

            items = itemData.GetItemById(ItemId);

            return items;
        }
    }
}