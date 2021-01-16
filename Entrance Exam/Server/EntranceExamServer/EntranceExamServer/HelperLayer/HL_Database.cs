using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EntranceExamServer.HelperLayer
{
    static class HL_Database
    {
        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand cmd = new SqlCommand();

        private static readonly string connectionString;        // ConfigurationManager.ConnectionStrings[""].ConnectionString
        private static Configuration config;


        /*************************************************************************************************************
         *                                                                                                           *
         *      Function executes a SQL Query that handles the SQLConnection and passing of the SQL command to       *
         *      the database. There is no dataset or datareader returned. It returns the default SQL number of       *
         *      rows affected in string format or an SQL error if the execution fails.                               *
         *                                                                                                           *
         *************************************************************************************************************/
        public static string ExecuteNonQuery(string conString, CommandType cmdType, string cmdText, SqlParameter[] sqlParams)
        {
            using (conn)
            {
                try
                {
                    string errorMessage = PrepareCommand(cmd, null, cmdType, cmdText, sqlParams);

                    if (errorMessage != null)
                        return errorMessage;

                    string affectedRowsCount = Convert.ToString(cmd.ExecuteNonQuery());
                    cmd.Parameters.Clear();

                    return affectedRowsCount;
                }
                catch (Exception ex)
                {
                    CloseConnection();
                    return ex.Message;
                }
            }
        }


        /*************************************************************************************************************
        *                                                                                                           *
        *      Function executes a SQL Data Adapter that handles the SQLConnection and passing of the SQL           *
        *      command to the database.  A datatable is returned.                                                     *
        *                                                                                                           *
        *************************************************************************************************************/
        public static DataTable ExecuteDataTable(CommandType cmdType, string cmdText, SqlParameter[] sqlParams)
        {
            DataTable dt = new DataTable();

            try
            {
                if (PrepareCommand(cmd, null, cmdType, cmdText, sqlParams) == null)
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    return dt;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /*************************************************************************************************************
         *                                                                                                           *
         *      Function executes a SQL Data Adapter that handles the SQLConnection and passing of the SQL           *
         *      command to the database.  A dataset is returned.                                                     *
         *                                                                                                           *
         *************************************************************************************************************/
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, SqlParameter[] sqlParams)
        {
            DataSet ds = new DataSet();

            try
            {
                if (PrepareCommand(cmd, null, cmdType, cmdText, sqlParams) == null)
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    return ds;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /*************************************************************************************************************
         *                                                                                                           *
         *                                        Open Database Connection                                           *
         *                                                                                                           *
         *************************************************************************************************************/
        private static void OpenConnection()
        {
            conn.ConnectionString = connectionString;
            conn.Open();
        }


        /*************************************************************************************************************
         *                                                                                                           *
         *                                        Close Database Connection                                          *
         *                                                                                                           *
         *************************************************************************************************************/
        private static void CloseConnection()
        {
            conn.Close();
        }

        public static string TestConnection()
        {
            try
            {
                OpenConnection();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            CloseConnection();

            return Convert.ToString(true);
        }


        /*************************************************************************************************************
         *                                                                                                           *
         *      Function construct SQL commands for execution. It opens the SQL Connection and includes              *
         *      command text, transaction if one is passed, and parameters in the SqlCommand cmd.                    *
         *      This is a pointer function that returns string of error if there are or null if nothing.             *
         *      It directly modifies the cmd object that is pointed to.                                              *
         *                                                                                                           *
         *************************************************************************************************************/
        private static string PrepareCommand(SqlCommand cmd, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] sqlParams)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    OpenConnection();

                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandTimeout = 180;

                if (trans != null)
                    cmd.Transaction = trans;

                cmd.CommandType = cmdType;

                if (sqlParams != null)
                {
                    foreach (SqlParameter param in sqlParams)
                        cmd.Parameters.Add(param);
                }
            }
            catch (SqlException ex)
            {
                CloseConnection();
                return ex.Message;
            }

            return null;
        }


        private static void SetConnectionString(string Server, string Username, string Password, string Database)
        {
            config = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            
            config.ConnectionStrings.ConnectionStrings["SqlServerConnection"].ConnectionString =
                String.Format("server={0};user={1};password={2};", Server, Username, Password, Database);

            config.ConnectionStrings.ConnectionStrings["SqlServerConnection"].ProviderName = "System.Data.SqlClient";

            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
