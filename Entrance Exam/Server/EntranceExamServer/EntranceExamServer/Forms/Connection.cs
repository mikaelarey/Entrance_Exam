using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EntranceExamServer.Forms
{
    public partial class Connection : Form
    {
        private bool passedConnectionTest = false;

        public Connection()
        {
            InitializeComponent();
        }

        private void btn_TestConnection_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            { 
                // Todo: Test connection
            }
            
        }

        private bool ValidateInput()
        {
            if (String.IsNullOrWhiteSpace(cb_Database_Engine.Text))
            {
                MessageBox.Show("Database Engine is required.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Todo: Prevent user from typing to the combobox
            
            if (cb_Database_Engine.SelectedIndex == 1)
            {
                MessageBox.Show("MySQL is not yet supported.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (String.IsNullOrWhiteSpace(tb_ServerName.Text)) 
            {
                MessageBox.Show("Server Name is required.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (String.IsNullOrWhiteSpace(tb_Username.Text))
            {
                MessageBox.Show("Username is required.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (String.IsNullOrWhiteSpace(tb_DatabaseName.Text))
            {
                MessageBox.Show("Database Name is required.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true; 
        }

        private void btn_SaveConnection_Click(object sender, EventArgs e)
        {
            if (passedConnectionTest)
            {
                // Todo: save connection
                // Todo: Restart the application
            }
            else
            {
                MessageBox.Show("Please make sure that the connection was passed to the test before proceeding", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TextBox_TextChange(object sender, EventArgs e)
        {
            MessageBox.Show(((TextBox)sender).Name);
            passedConnectionTest = false;
        }

        private void Connection_Load(object sender, EventArgs e)
        {
            cb_Database_Engine.Items.Add("SQL Server");
            cb_Database_Engine.Items.Add("MySQL");
        }

    }
}
