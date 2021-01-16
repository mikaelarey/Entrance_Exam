using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace SP.DataLayer
{
    static class Database
    {
        // Connection string
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;

        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter adapter;

        public static void Open() 
        {
            con.ConnectionString = connectionString;
            con.Open();
        } 

        public static void Close() {
            con.Close();
        }
    }
}
