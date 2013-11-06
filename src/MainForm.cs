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


    ////////////////////////////////////////
    ////////// Data Access Object //////////
    ////////////////////////////////////////

    [Table(Name = "Checks")]
    public class Check
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string id { get; set; }

        public string CheckNum { get; set; }
        public double Amount { get; set; }
        public string AmountLong { get; set; }

        public string Passer { get; set; }
        public string Address { get; set; }
        public string Account { get; set; }

        public char Status { get; set; }

        public string Employee { get; set; }
        public DateTime DateEntered { get; set; }

    }

    [Table(Name = "Accounts")]
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string id { get; set; }

        public string AccountNum { get; set; }
        public string RoutingNum { get; set; }
        public string Owner { get; set; }

    }

    [Table(Name = "Addresses")]
    public class Addresses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string id { get; set; }

        public string Street { get; set; }
        public string AptNo { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }

    }

    [Table(Name = "Banks")]
    public class Banks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string RoutingNum { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }

    }

    [Table(Name = "Configurations")]
    public class Configurations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string id { get; set; }

        public double FeeAmt { get; set; }

    }

    [Table(Name = "Employees")]
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public char Type { get; set; }
        public string Supervisor { get; set; }
        public string Store { get; set; }
        public string Login { get; set; }

    }

    [Table(Name = "Forms")]
    public class Forms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string id { get; set; }

        public string Letter1 { get; set; }
        public string Letter2 { get; set; }
        public string Letter3 { get; set; }
        public string Regulations { get; set; }
        public string Notices { get; set; }

    }

    [Table(Name = "Logins")]
    public class Logins
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; set; }

    }

    [Table(Name = "Passers")]
    public class Passers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }

    }

    [Table(Name = "Phones")]
    public class Phones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string id { get; set; }

        public string Number { get; set; }
        public string Passer { get; set; }

    }

    [Table(Name = "Stores")]
    public class Stores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Configuration { get; set; }
        public string Forms { get; set; }

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
