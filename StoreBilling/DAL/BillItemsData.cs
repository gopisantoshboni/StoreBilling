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
    public class BillItemsData
    {
        public void SaveBillItems(BillItems BillItems)
        {
            string CS = ConfigurationManager.ConnectionStrings["BillDbConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Insert into BillItems(BillNo,ItemId,Quantity,ItemPrice,Discount,TotalPrice) Values(@BillNo,@ItemId,@Quantity,@ItemPrice,@Discount,@TotalPrice)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@BillNo", BillItems.BillNo);
                cmd.Parameters.AddWithValue("@ItemId", BillItems.ItemId);
                cmd.Parameters.AddWithValue("@Quantity", BillItems.Quantity);
                cmd.Parameters.AddWithValue("@ItemPrice", BillItems.ItemPrice);
                cmd.Parameters.AddWithValue("@Discount", BillItems.Discount);
                cmd.Parameters.AddWithValue("@TotalPrice", BillItems.TotalPrice);
                con.Open();

                cmd.ExecuteNonQuery();
            }           
        }
    }
}