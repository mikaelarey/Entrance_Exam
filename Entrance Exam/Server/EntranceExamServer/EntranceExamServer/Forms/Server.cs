using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntranceExamServer.BusinessLayer;

namespace EntranceExamServer.Forms
{
    public partial class Server : Form
    {
        private Timer timer = new Timer();

        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            timer.Interval = 2000;
            timer.Tick += new System.EventHandler(InitialLoad);

            timer.Start();
        }

        private void InitialLoad(object sender, EventArgs e)
        {
            timer.Stop();

            string connectionMessage = BL_Server.TestConnection();

            if (connectionMessage.ToLower() == "true")
            {
                Login loginForm = new Login();
                loginForm.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show(connectionMessage, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult result = MessageBox.Show("Do you want to set new database connection?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Connection connForm = new Connection();
                    connForm.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thank you for using our application. The application will now exit.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
        }
    }
}
