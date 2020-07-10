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
    public class NameValuePairData
    {
        public NameValuePair  GetValue(string Name)
        {
            NameValuePair nameValuePair = new NameValuePair();
            string CS = ConfigurationManager.ConnectionStrings["BillDbConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM NameValuePair where Name = @Name", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", Name);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    nameValuePair.Value = rdr["Value"].ToString();
                    nameValuePair.Name = rdr["Name"].ToString();
                }
            }
            return nameValuePair;
        }
    }
}