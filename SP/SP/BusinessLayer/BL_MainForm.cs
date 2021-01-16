using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SP.DataLayer;

namespace SP.BusinessLayer
{
    static class BL_MainForm
    {
        public static DataTable GetUsers() 
        {
            DataTable dt = DL_MainForm.GetUsers();
            return dt;
        }

        public static int InsertData(string username, string password) 
        { 
            // Validation

            return DL_MainForm.InsertData(username, password);
        }
    }
}
