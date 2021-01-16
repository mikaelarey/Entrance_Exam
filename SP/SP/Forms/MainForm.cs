using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SP.BusinessLayer;

namespace SP.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BL_MainForm.InsertData(tb_Username.Text, tb_Password.Text) == 0)
            {
                MessageBox.Show("Operation Fails");
                return;
            }

            MessageBox.Show("Successfully Inserted data");
            GetUsers();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetUsers();
            
        }

        private void GetUsers() 
        {
            GV_UsersTable.DataSource = BL_MainForm.GetUsers();
        }
    }
}
