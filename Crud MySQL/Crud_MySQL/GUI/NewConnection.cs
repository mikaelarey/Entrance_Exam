using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crud_MySQL.GUI
{
    public partial class NewConnection : Form
    {
        public NewConnection()
        {
            InitializeComponent();
        }

        private void NewConnection_Load(object sender, EventArgs e)
        {

        }

        private void NewConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
