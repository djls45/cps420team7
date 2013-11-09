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
                Addresses Address = new Addresses();
                Address.Street = cd.textBox3.Text;
                Address.City = cd.textBox4.Text;
                Address.State = cd.textBox13.Text;
                Address.PostalCode = cd.textBox5.Text;

                Passers Passer = new Passers();
                Passer.FName = cd.textBox1.Text;
                Passer.LName = cd.textBox2.Text;

                Accounts Account = new Accounts();
                Account.RoutingNum = cd.textBox6.Text;
                Account.AccountNum = cd.textBox7.Text;

                Check ch = new Check();
                ch.Addresses = Address;
                ch.Passers = Passer;
                ch.Accounts = Account;
                ch.CheckNum = cd.textBox8.Text;
                ch.Amount = Convert.ToDecimal(cd.textBox9.Text);
                ch.Recipient = cd.textBox12.Text;
                ch.ImageFile = cd.textBox11.Text;

                CheckDAO.Update(ch);
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
