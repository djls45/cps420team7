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
            ErrorLabel.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = LoginDAO.FindLogin(userIdText.Text);
            if (l != null && pwdText.Text != null && l.Password == pwdText.Text)
            {
                ErrorLabel.Hide();
                MainForm main = new MainForm();
                main.currentUser = EmployeeDAO.LoadAllEmployees().Find(emp => emp.Login == l.id);
                    //EmployeeDAO.FindEmployee(l.id);
                main.login = l;
                main.logindlg = this;
                this.Hide();
                main.ShowDialog();
            }
            else
            {
                ErrorLabel.Show();
            }
        }
    }
}
