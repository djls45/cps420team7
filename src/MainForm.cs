using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CheckTracker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load size and location from config file and set form
            this.Size = Properties.Settings.Default.MainFormSize;
            this.Location = Properties.Settings.Default.MainFormLocation;

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckDialog cd = new CheckDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                // set all attributes

                Check ch = new Check();
                ch.DateEntered = DateTime.Now;
                //ch.Passers = p;
                //ch.Addresses = adr;
                //ch.Accounts = act;
                //ch.Employees = emp;
                ch.Amount = Convert.ToDecimal(cd.amountBox.Text);
                ch.Status = '1';
                ch.Account = ((Account)cd.AccountChoice.SelectedItem).id;
                ch.Employee = 0;
                ch.DateEntered = DateTime.Now;

                CheckDAO.Create(ch);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckDialog cd = new CheckDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {

            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", 
                "Confirm Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                //Set record's deleted flag
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
    }


    

}

