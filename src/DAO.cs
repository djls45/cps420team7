using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;


namespace CheckTracker
{
    ////////////////////////////////////////
    ////////// Data Access Object //////////
    ////////////////////////////////////////

    [System.Data.Linq.Mapping.Table(Name = "Checks")]
    public class Check
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string CheckNum { get; set; }
        public decimal Amount { get; set; }
        public string AmountLong { get; set; }

        public Guid Passer { get; set; }
        [ForeignKey("Passer")]
        public Passers Passers { get; set; }

        public Guid Address { get; set; }
        [ForeignKey("Address")]
        public Addresses Addresses { get; set; }
        
        public Guid Account { get; set; }
        [ForeignKey("Account")]
        public Accounts Accounts { get; set; }

        public char Status { get; set; }

        public Guid Employee { get; set; }
        [ForeignKey("Employee")]
        public Employees Employees { get; set; }

        public DateTime DateEntered { get; set; }

        public string Recipient { get; set; }
        public string ImageFile { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Accounts")]
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string AccountNum { get; set; }

        public string RoutingNum { get; set; }
        [ForeignKey("RoutingNum")]
        public Banks Banks { get; set; }

        public Guid Owner { get; set; }
        [ForeignKey("Owner")]
        public Passers Passers { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Addresses")]
    public class Addresses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string Street { get; set; }
        public string AptNo { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Banks")]
    public class Banks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string RoutingNum { get; set; }

        public string Name { get; set; }
        public Guid Location { get; set; }
        [ForeignKey("Location")]
        public Addresses Addresses { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Configurations")]
    public class Configurations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public double FeeAmt { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Employees")]
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public char Type { get; set; }

        public Guid Supervisor { get; set; }
        [ForeignKey("Supervisor")]
        public Employees Employee { get; set; }
        
        public Guid Store { get; set; }
        [ForeignKey("Store")]
        public Stores Stores { get; set; }

        public string Login { get; set; }
        [ForeignKey("Login")]
        public Logins Logins { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Forms")]
    public class Forms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string Letter1 { get; set; }
        public string Letter2 { get; set; }
        public string Letter3 { get; set; }
        public string Regulations { get; set; }
        public string Notices { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Logins")]
    public class Logins
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        //[Timestamp]
        public DateTime Date { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Passers")]
    public class Passers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }

        public Guid Address { get; set; }
        [ForeignKey("Address")]
        public Addresses Addresses { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Phones")]
    public class Phones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string Number { get; set; }
        
        public Guid Passer { get; set; }
        [ForeignKey("Passer")]
        public Passers Passers { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Stores")]
    public class Stores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string Name { get; set; }

        public Guid Location { get; set; }
        [ForeignKey("Location")]
        public Addresses Addresses { get; set; }
        
        public Guid Configuration { get; set; }
        [ForeignKey("Configuration")]
        public Configurations Configurations { get; set; }
        
        public Guid Form { get; set; }
        [ForeignKey("Form")]
        public Forms Forms { get; set; }

    }

    class CheckTrackerContext : DbContext
    {
        // Constructor: provides connection string <connStr> to superclass constructor
        public CheckTrackerContext(string connStr) : base(connStr) { }

        public DbSet<Check> Checks { get; set; }
    }

    class CheckDAO
    {
        public static List<Check> LoadAll()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
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

        public static void Update(Check AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Check record = db.Checks.Single(x => x.id == AE.id);
                //record.CheckNum = AE.CheckNum;
                //record.Amount = AE.Amount;
                //record.AmountLong = AE.AmountLong;
                //record.Status = AE.Status;
                //record.DateEntered = AE.DateEntered;

                //record.Passer = AE.Passer;
                ////record.Passers = AE.Passers;
                //record.Address = AE.Address;
                ////record.Addresses = AE.Addresses;
                //record.Account = AE.Account;
                ////record.Accounts = AE.Accounts;
                //record.Employee = AE.Employee;
                ////record.Employees = AE.Employees;

                record = AE;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Check AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                db.Checks.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Check AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Check record = db.Checks.Single(x => x.id == AE.id);
                //db.Checks.Remove(record);
                record.Status = 'D';
                db.SaveChanges();
                return;
            }
        }
    }
}
