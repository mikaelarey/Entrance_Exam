using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntranceExamServer.HelperLayer;

namespace EntranceExamServer.DataLayer
{
    static class DL_Server
    {
        public static string TestConnection()
        {
            return HL_Database.TestConnection();
        }
    }
}
