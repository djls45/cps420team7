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
using System.Collections.Generic;

namespace CheckTracker
{
    [Table(Name = "Checks")]
    public class AddressEntry
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public int id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string StateTerritory { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public double Amount { get; set; }
        public string AmountLong { get; set; }

        public String AccountNum { get; set; }
        public String RoutingNum { get; set; }

    }

    class CheckTrackerContext : DbContext
    {
        // Constructor: provides connection string <connStr> to superclass constructor
        public CheckTrackerContext(string connStr) : base(connStr) { }

        public DbSet<AddressEntry> AddressEntries { get; set; }
    }

    class AddressEntryDAO
    {
        List<AddressEntry> LoadAll()
        {
            using (var db = new CheckTrackerContext("server=localhost;database=AddressBook;"))
            {
                // Define a LinQ Query
                var query = from ae in db.AddressEntries
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<AddressEntry> AEList = null;

                foreach (AddressEntry ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        void Update(AddressEntry AE)
        {
            using (var db = new CheckTrackerContext("server=localhost;database=AddressBook;"))
            {
                var record = db.AddressEntries.Single(x => x.id == AE.id);
                record.Name = AE.Name;
                record.Email = AE.Email;
                db.SaveChanges();
                return;
            }
        }

        void Create(AddressEntry AE)
        {
            using (var db = new CheckTrackerContext("server=localhost;database=AddressBook;"))
            {
                db.AddressEntries.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        void Delete(AddressEntry AE)
        {
            using (var db = new CheckTrackerContext("server=localhost;database=AddressBook;"))
            {
                var record = db.AddressEntries.Single(x => x.id == AE.id);
                db.AddressEntries.Remove(record);
                db.SaveChanges();
                return;
            }
        }
    }

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'addressBookDataSet.AddressEntry' table. You can move, or remove it, as needed.
            this.addressEntryTableAdapter.Fill(this.addressBookDataSet.AddressEntry);

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
    }
}
