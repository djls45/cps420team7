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

            // TODO: This line of code loads data into the 'addressBookDataSet.AddressEntry' table. You can move, or remove it, as needed.
            //this.addressEntryTableAdapter.Fill(this.addressBookDataSet.AddressEntry);
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckDialog cd = new CheckDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Passers p = new Passers();
                Addresses adr = new Addresses();
                Accounts act = new Accounts();
                Employees emp = new Employees();
                Check ch = new Check();
                //ch.property = textbox.text;

                adr.Street = cd.addressBox.Text;
                adr.City = cd.cityBox.Text;
                adr.State = cd.stateBox.Text;
                adr.PostalCode = cd.postalBox.Text;
                adr.AptNo = cd.aptBox.Text;
                p.FName = cd.firstNameBox.Text;
                p.LName = cd.lastNameBox.Text;
                p.Addresses = adr;
                act.AccountNum = cd.accountNumBox.Text;
                act.Passers = p;
                act.RoutingNum = cd.routingNumBox.Text;

                ch.Passers = p;
                ch.Addresses = adr;
                ch.Accounts = act;
                ch.Employees = emp;
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
