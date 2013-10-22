using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckTracker
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pwdText.Clear();
            userIdText.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.ShowDialog();
        }
    }
}
