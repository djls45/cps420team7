using System;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Data.Linq;
using System.Data.Entity;
using System.Data.Linq.Mapping;
using System.Collections.Generic;

namespace CheckTracker
{
    [Table(Name = "AddressEntry")]
    public class AddressEntry
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    
    class CheckTrackerContext : DbContext
    {
        // Constructor: provides connection string <connStr> to superclass constructor
        public CheckTrackerContext(string connStr): base(connStr)  {    }
        
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
                
                foreach(AddressEntry ae in results)
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

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
