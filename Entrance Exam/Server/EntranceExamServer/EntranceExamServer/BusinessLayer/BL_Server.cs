using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntranceExamServer.DataLayer;

namespace EntranceExamServer.BusinessLayer
{
    static class BL_Server
    {
        public static string TestConnection() 
        {
            return DL_Server.TestConnection();
        }

        
    }
}
