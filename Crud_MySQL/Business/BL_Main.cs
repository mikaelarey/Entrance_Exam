using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crud_MySQL.Business
{
    static class BL_Main
    {
        private static Data.Database.Connecttion connection = new Data.Database.Connecttion();
        public static Data.Database.ConnectionState connectionState = connection.state;
        public static Data.Database.DatabaseState databaseState = connection.dbState;

        public static string ConnectToServer()
        {
            connection.Open();
            connectionState = connection.state;

            if (connectionState == Data.Database.ConnectionState.Connected)
                return "Server Connection Successful ...";
                
            if (connectionState == Data.Database.ConnectionState.ConnectionFailed)
                return "Server Connection Failed ...";

            return null;
        }

        public static string IsDatabseExists()
        {
            connection.IsDatabseExists();
            databaseState = connection.dbState;

            if (databaseState == Data.Database.DatabaseState.Exists)
                return "Database Connection Successful ...";

            if (databaseState == Data.Database.DatabaseState.NotExists)
                return "Database For This Application Did Not Exists ...";

            return null;
        }
    }
}
