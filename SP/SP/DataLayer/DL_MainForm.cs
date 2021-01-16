using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SP.DataLayer
{
    class DL_MainForm
    {
        public static DataTable GetUsers() 
        {
            Database.Open();

            DataTable dtData = new DataTable();
            Database.cmd.CommandText = "Get_Users";
            Database.cmd.CommandType = CommandType.StoredProcedure;
            Database.cmd.Connection = Database.con;

            Database.adapter = new SqlDataAdapter(Database.cmd);
            Database.adapter.Fill(dtData);

            Database.Close();

            return dtData;  	
        }

        public static int InsertData(string username, string password) 
        {
            Database.Open();

            DataTable dtData = new DataTable();
            Database.cmd.CommandText = "Insert_User";
            Database.cmd.CommandType = CommandType.StoredProcedure;
            Database.cmd.Connection = Database.con;

            Database.cmd.Parameters.AddWithValue("@Username", username);
            Database.cmd.Parameters.AddWithValue("@Password", password);

            int success = Database.cmd.ExecuteNonQuery();
            
            Database.Close();

            return success;	
        }
    }
}
