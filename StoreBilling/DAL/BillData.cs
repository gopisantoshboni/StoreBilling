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
    public class BillData
    {
        public int SaveBill(Bill Bill)
        {           
            string CS = ConfigurationManager.ConnectionStrings["BillDbConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Insert into Bill(Price,GST,TotalPrice) Values(@Price,@GST,@TotalPrice); SELECT SCOPE_IDENTITY()", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Price", Bill.Price);
                cmd.Parameters.AddWithValue("@GST", Bill.GST);
                cmd.Parameters.AddWithValue("@TotalPrice", Bill.TotalPrice);
                con.Open();

                Bill.BillNo = (int) (decimal) cmd.ExecuteScalar();
            }
            return Bill.BillNo;
        }
    }
}