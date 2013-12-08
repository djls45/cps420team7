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
    public partial class LoginUpdateForm : Form
    {
        public Login login;

        public LoginUpdateForm()
        {
            InitializeComponent();
        }

        public LoginUpdateForm(Login lgn)
        {
            InitializeComponent();
            login = lgn;
            UsernameBox.Text = login.Username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (Password1Text.Text == Password2Text.Text)
            {
                login.Username = UsernameBox.Text;
                login.Password = Password1Text.Text;
                login.Date = DateTime.Now;
            }
            else
            {
                MessageBox.Show("The passwords don't match.", "Password Error", MessageBoxButtons.OK);
                return;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
