using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StoreBilling.Models;

namespace StoreBilling.DAL
{
    public class ItemData
    {
        public List<Items> GetItemsOnSearch(string SearchedString)
        {
            List<Items> itemsList = new List<Items>();
            string CS = ConfigurationManager.ConnectionStrings["BillDbConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Items where Name like @search", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@search", "%" + SearchedString + "%");
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var item = new Items();

                    item.ItemId = Convert.ToInt32(rdr["ItemId"]);
                    item.Name = rdr["Name"].ToString();
                    item.ItemTypeId = Convert.ToInt32(rdr["ItemTypeId"]);
                    item.Price = float.Parse(rdr["Price"].ToString());

                    itemsList.Add(item);
                }
            }
            return itemsList;
        }

        public Items GetItemById(int ItemId)
        {
            Items items = new Items();
            ItemType itemType = new ItemType();
            string CS = ConfigurationManager.ConnectionStrings["BillDbConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Items I INNER JOIN ItemType IT on I.ItemTypeId = IT.ItemTypeId where I.ItemId = @ItemId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ItemId", ItemId);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    items.ItemId = Convert.ToInt32(rdr["ItemId"]);
                    items.Name = rdr["Name"].ToString();
                    items.ItemTypeId = Convert.ToInt32(rdr["ItemTypeId"]);
                    items.Price = float.Parse(rdr["Price"].ToString());

                    itemType.ItemTypeId= Convert.ToInt32(rdr["ItemTypeId"]);
                    itemType.Name = rdr["ItemType"].ToString();
                    itemType.discount = float.Parse(rdr["Discount"].ToString());

                    items.ItemType = itemType;
                }
            }

            return items;
        }
    }
}