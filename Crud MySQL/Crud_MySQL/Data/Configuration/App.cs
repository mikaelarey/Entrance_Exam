using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Crud_MySQL.Data.Configuration
{
    class App
    {
        private System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

        private string Server;
        private string Username;
        private string Password;
        private string Database;

        public App()
        {
            this.Server = ConfigurationManager.AppSettings["Server"].ToString();
            this.Username = ConfigurationManager.AppSettings["Username"].ToString();
            this.Password = ConfigurationManager.AppSettings["Password"].ToString();
            this.Database = ConfigurationManager.AppSettings["Database"].ToString();

            this.UpdateConnectionString(String.Format("server={0};user={1};password={2};",
                this.Server, this.Username, this.Password));
        }

        public void AddOrUpdateAppSettings(string key, string value)
        {
            /*
             * The changes will not reflect at the app.config of the project files
             * Open the config file from the debug folder to see the changes
             * 
             */

            if (config.AppSettings.Settings[key] == null)
            {
                // Add New Settings
                config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);

                return;
            }

            // Update New Settings
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);

            return;
        }

        public void UpdateConnectionString(string value)
        {
            config.ConnectionStrings.ConnectionStrings["MySQLConnection"].ConnectionString = value;
            // config.ConnectionStrings.ConnectionStrings["MySQLConnection"].ProviderName = "System.Data.SqlClient";

            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
