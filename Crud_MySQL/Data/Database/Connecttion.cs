using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Crud_MySQL.Data.Database
{
    enum ConnectionState
    {
        NotConnected,
        Connected,
        ConnectionFailed
    }

    enum DatabaseState 
    {
        Undefined,
        NotExists,
        Exists,
        Created,
        Deleted
    }

    class Connecttion
    {
        public ConnectionState state = ConnectionState.NotConnected;
        public DatabaseState dbState = DatabaseState.Undefined;

        // Connection string
        private readonly string connectionString;

        // Create a variable that will holds a new mysql connection
        public MySqlConnection connection;

        // Contructor
        public Connecttion()
        {
            Configuration.App appSettings = new Configuration.App();

            this.connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        }

        // Open New Connection
        public void Open() 
        {
            try
            {
                if (this.state == ConnectionState.Connected)
                    return;

                this.connection = new MySqlConnection(this.connectionString);
                connection.Open();

                this.state = ConnectionState.Connected;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, 
                                                     "Error Message", 
                                                     System.Windows.Forms.MessageBoxButtons.OK,
                                                     System.Windows.Forms.MessageBoxIcon.Error);

                this.state = ConnectionState.ConnectionFailed;
            }
        }

        // Close Existig Connection
        public void Close()
        {
            if (this.state == ConnectionState.Connected)
                connection.Close();

            this.state = ConnectionState.NotConnected;
        }


        /****************************************************************************************************************
         *                                                                                                              *
         *                          This methods is only executed on initial load of the application.                   *
         *                                                                                                              *
         ****************************************************************************************************************/
 
        // Check if database exists
        public void IsDatabseExists() 
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = SqlCommand.CheckDatabase;
            cmd.Connection = connection;

            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
                this.dbState = DatabaseState.Exists;
            
            else 
                this.dbState = DatabaseState.NotExists;

            reader.Close();
            reader.Dispose();
        }
    }
}
