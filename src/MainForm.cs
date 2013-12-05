using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CheckTracker
{
    public partial class MainForm : Form
    {
        public Employee currentUser;
        public Login login;
        public LoginDialog logindlg;

        public MainForm()
        {
            InitializeComponent();
            LoadChecks();
        }

        private void LoadChecks()
        {
            List<Check> LC;
            LC = CheckDAO.LoadAllCurrentChecks();
            CheckDataGrid.DataSource = LC;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load size and location from config file and set form
            this.Size = Properties.Settings.Default.MainFormSize;
            this.Location = Properties.Settings.Default.MainFormLocation;
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckDialog cd = new CheckDialog();
            cd.employee = currentUser;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                CheckDAO.Create(cd.check);
                LoadChecks();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckDialog cd = new CheckDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Check ch = cd.check;
                ch.Employee = currentUser.id;

                CheckDAO.Update(ch);
                LoadChecks();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?",
                "Confirm Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                //get selected check entry

                switch (currentUser.Type)
                {
                    case "A": // administrator
                        //delete
                        break;
                    case "M": // manager
                    case "U": // user
                        //set status to "D"
                        break;
                    default: // do nothing
                        break;
                }
            }
        }

        private void viewHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryForm history = new HistoryForm();
            history.ShowDialog();
        }

        // When the form location is changed, save to user config file
        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainFormLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        // When the form size is changed, save to user config file
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainFormSize = this.Size;
            Properties.Settings.Default.Save();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logindlg.Show();
        }

        private void toolStripMenuItemCreateEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm ef = new EmployeeForm();
            if (ef.DialogResult == DialogResult.OK)
            {
                EmployeeDAO.Create(ef.Employee);
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginUpdateForm luf = new LoginUpdateForm();
            luf.login = login;
            if (luf.DialogResult == DialogResult.OK)
            {
                LoginDAO.Create(luf.login);
            }
        }

        private void HandleDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore data errors
        }
    }
    
}

