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

        private void MenuCreateCheck(object sender, EventArgs e)
        {
            CheckDialog cd = new CheckDialog();
            cd.employee = currentUser;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                CheckDAO.Create(cd.check);
                LoadChecks();
            }
        }

        private void MenuUpdateCheck(object sender, EventArgs e)
        {
            Check ch = (Check)CheckDataGrid.CurrentRow.DataBoundItem;
            if (ch == null)
            {
                MessageBox.Show("Please select a row to edit and try again.", 
                                "No Row Selected", MessageBoxButtons.OK);
            }
            else
            {
                CheckDialog cd = new CheckDialog(ch);
                cd.employee = currentUser;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    CheckDAO.Update(cd.check);
                    LoadChecks();
                }
            }
        }

        private void MenuDeleteCheck(object sender, EventArgs e)
        {
            //get selected check entry
            Check ch = (Check)CheckDataGrid.CurrentRow.DataBoundItem;
            if (ch == null)
            {
                MessageBox.Show("Please select a row to delete and try again.",
                                "No Row Selected", MessageBoxButtons.OK);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this record?",
                    "Confirm Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    switch (currentUser.Type)
                    {
                        case "A": // administrator
                            //delete
                            CheckDAO.Delete(ch);
                            break;
                        case "M": // manager
                        case "U": // user
                            //set status to "D"
                            ch.Status = "D";
                            CheckDAO.Update(ch);
                            break;
                        default: // do nothing
                            break;
                    }//switch
                    LoadChecks();
                }//if user wants to delete
            }//if check exists
        }//menu item: delete check

        private void MenuChecksHistory(object sender, EventArgs e)
        {
            HistoryForm history = new HistoryForm();
            history.ShowDialog();
        }

        // Save window location to user config file when it is moved on the screen
        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainFormLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        // When the window size is changed, save to user config file
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainFormSize = this.Size;
            Properties.Settings.Default.Save();
        }

        //logout
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logindlg.Show();
        }

        private void MenuCreateEmployee(object sender, EventArgs e)
        {
            EmployeeForm ef = new EmployeeForm();
            if (ef.ShowDialog() == DialogResult.OK)
            {
                EmployeeDAO.Create(ef.Employee);
            }
        }

        private void MenuCreateStore(object sender, EventArgs e)
        {
            StoreForm sf = new StoreForm();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                StoreDAO.Create(sf.Store);
            }
        }

        private void MenuChangePassword(object sender, EventArgs e)
        {
            LoginUpdateForm luf = new LoginUpdateForm(login);
            if (luf.ShowDialog() == DialogResult.OK)
            {
                LoginDAO.Create(luf.login);
            }
        }

        private void HandleDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore data errors in table view
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string about = "CheckTracker was developed " +
                           "in the fall of 2013 by\n\n" +
                           "\tJed Schaaf\n" +
                           "\tJosiah Rickerd\n" +
                           "\tand Jason McVey\n\n" +
                           "for CpS 420 - Software Development\n" +
                           "at Bob Jones Univeristy";
            MessageBox.Show(about, "About CheckTracker", MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
    
}

