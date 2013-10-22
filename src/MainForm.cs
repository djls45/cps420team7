using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Linq;
using System.Data.Entity;
using System.Data.Linq.Mapping;

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
            // TODO: This line of code loads data into the 'addressBookDataSet.AddressEntry' table. You can move, or remove it, as needed.
            //this.addressEntryTableAdapter.Fill(this.addressBookDataSet.AddressEntry);

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckDialog cd = new CheckDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {

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
    }


    ////////////////////////////////////////
    ////////// Data Access Object //////////
    ////////////////////////////////////////

    [Table(Name = "Checks")]
    public class Check
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public int id { get; set; }

        public string CheckNum { get; set; }
        public double Amount { get; set; }
        public string AmountLong { get; set; }
        public string AccountNum { get; set; }

        public int Passer { get; set; }
        public int Address { get; set; }
        public int Bank { get; set; }

        public bool Deleted { get; set; }
        public bool Paid { get; set; }

    }

    class CheckTrackerContext : DbContext
    {
        // Constructor: provides connection string <connStr> to superclass constructor
        public CheckTrackerContext(string connStr) : base(connStr) { }

        public DbSet<Check> Checks { get; set; }
    }

    class AddressEntryDAO
    {
        List<Check> LoadAll()
        {
            using (var db = new CheckTrackerContext("server=localhost;database=AddressBook;"))
            {
                // Define a LinQ Query
                var query = from ae in db.Checks
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Check> AEList = null;

                foreach (Check ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        void Update(Check AE)
        {
            using (var db = new CheckTrackerContext("server=localhost;database=AddressBook;"))
            {
                var record = db.Checks.Single(x => x.id == AE.id);
                record.CheckNum = AE.CheckNum;
                record.Amount = AE.Amount;
                record.AmountLong = AE.AmountLong;
                record.AccountNum = AE.AccountNum;
                record.Address = AE.Address;
                record.Bank = AE.Bank;
                record.Deleted = AE.Deleted;
                record.Paid = AE.Paid;
                record = AE;
                db.SaveChanges();
                return;
            }
        }

        void Create(Check AE)
        {
            using (var db = new CheckTrackerContext("server=localhost;database=AddressBook;"))
            {
                db.Checks.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        void Delete(Check AE)
        {
            using (var db = new CheckTrackerContext("server=localhost;database=AddressBook;"))
            {
                var record = db.Checks.Single(x => x.id == AE.id);
                //db.Checks.Remove(record);
                record.Deleted = true;
                db.SaveChanges();
                return;
            }
        }
    }

}
