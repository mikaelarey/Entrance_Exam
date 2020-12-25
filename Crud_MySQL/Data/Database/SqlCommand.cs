using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crud_MySQL.Data.Database
{
    static class SqlCommand
    {
        public static string CheckDatabase = @"SELECT SCHEMA_NAME
                                      FROM INFORMATION_SCHEMA.SCHEMATA
                                      WHERE SCHEMA_NAME = '" + 
                                      System.Configuration.ConfigurationManager.AppSettings["Database"].ToString() + 
                                      "'";
    }
}
