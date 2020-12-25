using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Crud_MySQL.Business;

namespace Crud_MySQL.GUI
{
    public partial class Main : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.timer.Interval = 1000;
            this.timer.Tick += new EventHandler(timer_Tick);

            this.timer.Start();
        }

        private void ConnectToServer()
        {
            label2.Text = BL_Main.ConnectToServer();
            this.timer.Start();
        }

        private void IsDatabaseExists()
        {
            label2.Text = BL_Main.IsDatabseExists();
        }

        private void CreateDatabase()
        { 
        
        }

        private void RedirectToLoginForm() 
        {
            
        }

        private void DatabaseNotExists()
        { 
        
        }

        private void CreateNewConnection()
        {
            var connectionForm = new NewConnection();
            connectionForm.Show();
        }

        private void ConnectionFailed()
        {
            DialogResult result = MessageBox.Show("Do you want to connect to another database server?",
                                                  "Confirmation",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.CreateNewConnection();

            else
                Application.Exit();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.timer.Stop();

            if (BL_Main.connectionState == Data.Database.ConnectionState.NotConnected)
                this.ConnectToServer();

            else if (BL_Main.connectionState == Data.Database.ConnectionState.ConnectionFailed)
                this.ConnectionFailed();

            else if (BL_Main.connectionState == Data.Database.ConnectionState.Connected && BL_Main.databaseState == Data.Database.DatabaseState.Undefined)
                this.IsDatabaseExists();

            else if (BL_Main.connectionState == Data.Database.ConnectionState.Connected && BL_Main.databaseState == Data.Database.DatabaseState.NotExists)
                this.DatabaseNotExists();

            else if (BL_Main.connectionState == Data.Database.ConnectionState.Connected && BL_Main.databaseState == Data.Database.DatabaseState.Exists)
                this.RedirectToLoginForm();

            else
            {
                MessageBox.Show("Somethind went wrong. The application will now exit.",
                                "Erorr Message",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);

                Application.Exit();
            }
                
        }

    }
}
