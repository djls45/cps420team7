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
using System.Data.Entity.Infrastructure;


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
        public Passer Passers { get; set; }

        public Guid Address { get; set; }
        [ForeignKey("Address")]
        public Address Addresses { get; set; }
        
        public Guid Account { get; set; }
        [ForeignKey("Account")]
        public Account Accounts { get; set; }

        public char Status { get; set; }

        public Guid Employee { get; set; }
        [ForeignKey("Employee")]
        public Employee Employees { get; set; }

        public DateTime DateEntered { get; set; }

        public string Recipient { get; set; }
        public string ImageFile { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Accounts")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string AccountNum { get; set; }

        public string RoutingNum { get; set; }
        [ForeignKey("RoutingNum")]
        public Bank Banks { get; set; }

        public Guid? Owner { get; set; }
        [ForeignKey("Owner")]
        public Passer Passers { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Addresses")]
    public class Address
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
        public string Phone { get; set; }

        new public string ToString()
        {
            return Street + " " + AptNo + ", " + City + ", " + State + ", " + PostalCode + " (" + Phone + ")";
        }
    }

    [System.Data.Linq.Mapping.Table(Name = "Banks")]
    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public string RoutingNum { get; set; }

        public string Name { get; set; }
        public Guid Location { get; set; }
        [ForeignKey("Location")]
        public Address Addresses { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Configurations")]
    public class Configuration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public double FeeAmt { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public char Type { get; set; }

        public Guid Supervisor { get; set; }
        [ForeignKey("Supervisor")]
        public Employee EmpSup { get; set; }
        
        public Guid Store { get; set; }
        [ForeignKey("Store")]
        public Stores Stores { get; set; }

        public Guid Login { get; set; }
        [ForeignKey("Login")]
        public Login Logins { get; set; }

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
    public class Login
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
    public class Passer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }

        public Guid? Address { get; set; }
        [ForeignKey("Address")]
        public Address Addresses { get; set; }

    }

    [System.Data.Linq.Mapping.Table(Name = "Stores")]
    public class Stores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // required for non auto-generated PK
        public Guid id { get; set; }

        public string Name { get; set; }

        public Guid? Location { get; set; }
        [ForeignKey("Location")]
        public Address Addresses { get; set; }
        
        public Guid Configuration { get; set; }
        [ForeignKey("Configuration")]
        public Configuration Configurations { get; set; }
        
        public Guid Form { get; set; }
        [ForeignKey("Form")]
        public Forms Forms { get; set; }

    }

    public class CheckTrackerContext : DbContext
    {
        // Constructor: provides connection string <connStr> to superclass constructor
        public CheckTrackerContext(string connStr) : base(connStr) { }
        public CheckTrackerContext() : base() { }

        public DbSet<Check> Checks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Forms> Forms { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Passer> Passers { get; set; }
        public DbSet<Stores> Stores { get; set; }
    }

    public class CheckTrackerContextFactory : IDbContextFactory<CheckTrackerContext>
    {
        public CheckTrackerContext Create()
        {
            return new CheckTrackerContext("CheckTrackerConnectionString");
        }
    }
    class CheckDAO
    {
        ////////// Checks //////////
        public static List<Check> LoadAllChecks()
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
                Guid g = record.id;
                record = AE;
                record.id = g;
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

    class AccountDAO
    {
        ////////// Accounts //////////
        public static List<Account> LoadAllAccounts()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                // Define a LinQ Query
                var query = from ae in db.Accounts
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Account> AEList = null;

                foreach (Account ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Account AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Account record = db.Accounts.Single(x => x.id == AE.id);
                Guid g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Account AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                db.Accounts.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Account AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Account record = db.Accounts.Single(x => x.id == AE.id);
                db.Accounts.Remove(record);
                db.SaveChanges();
                return;
            }
        }
    }

    class AddressDAO
    {
        ////////// Addresses //////////
        public static List<Address> LoadAllAddresses()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                // Define a LinQ Query
                var query = from ae in db.Addresses
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Address> AEList = null;

                foreach (Address ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Address AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Address record = db.Addresses.Single(x => x.id == AE.id);
                Guid g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Address AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                db.Addresses.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Address AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Address record = db.Addresses.Single(x => x.id == AE.id);
                db.Addresses.Remove(record);
                db.SaveChanges();
                return;
            }
        }
    }

    class BankDAO
    {
        ////////// Banks //////////
        public static List<Bank> LoadAllBanks()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                // Define a LinQ Query
                var query = from ae in db.Banks
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Bank> AEList = null;

                foreach (Bank ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Bank AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Bank record = db.Banks.Single(x => x.RoutingNum == AE.RoutingNum);
                string id = record.RoutingNum;
                record = AE;
                record.RoutingNum = id;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Bank AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                db.Banks.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Bank AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Bank record = db.Banks.Single(x => x.RoutingNum == AE.RoutingNum);
                db.Banks.Remove(record);
                db.SaveChanges();
                return;
            }
        }
    }

    class ConfigDAO
    {
        ////////// Configurations //////////
        public static List<Configuration> LoadAllConfigs()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                // Define a LinQ Query
                var query = from ae in db.Configurations
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Configuration> AEList = null;

                foreach (Configuration ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Configuration AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Configuration record = db.Configurations.Single(x => x.id == AE.id);
                Guid g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Configuration AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                db.Configurations.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Configuration AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Configuration record = db.Configurations.Single(x => x.id == AE.id);
                db.Configurations.Remove(record);
                db.SaveChanges();
                return;
            }
        }
    }

    class EmployeeDAO
    {
        ////////// Employees //////////
        public static List<Employee> LoadAllEmployees()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                // Define a LinQ Query
                var query = from ae in db.Employees
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Employee> AEList = null;

                foreach (Employee ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Employee AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Employee record = db.Employees.Single(x => x.id == AE.id);
                Guid g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Employee AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                db.Employees.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Employee AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Employee record = db.Employees.Single(x => x.id == AE.id);
                db.Employees.Remove(record);
                db.SaveChanges();
                return;
            }
        }
    }

    class FormsDAO
    {
        ////////// Forms //////////
        public static List<Forms> LoadAllForms()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                // Define a LinQ Query
                var query = from ae in db.Forms
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Forms> AEList = null;

                foreach (Forms ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Forms AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Forms record = db.Forms.Single(x => x.id == AE.id);
                Guid g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Forms AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                db.Forms.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Forms AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Forms record = db.Forms.Single(x => x.id == AE.id);
                db.Forms.Remove(record);
                db.SaveChanges();
                return;
            }
        }
    }

    class LoginDAO
    {
        ////////// Logins //////////
        public static List<Login> LoadAllLogins()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                // Define a LinQ Query
                var query = from ae in db.Logins
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Login> AEList = null;

                foreach (Login ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static Login FindLogin(string username)
        {
            using (var db = new CheckTrackerContext("AddressBookConnectionString"))
            {
                Login login;
                var query = from l in db.Logins
                            where l.Username == username
                            group l by l.Date into i
                            select i.OrderByDescending(t => t.Date).First();
                login = query.ToList().First();
                return login;
            }
        }

        public static void Update(Login AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Login record = db.Logins.Single(x => x.id == AE.id);
                //AE.Date = DateTime.Now;
                //AE.id = Guid.NewGuid();
                //db.Logins.Add(AE);
                record = AE;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Login AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                db.Logins.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Login AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Login record = db.Logins.Single(x => x.id == AE.id);
                db.Logins.Remove(record);
                db.SaveChanges();
                return;
            }
        }
    }

    class PasserDAO
    {
        ////////// Passers //////////
        public static List<Passer> LoadAllPassers()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                // Define a LinQ Query
                var query = from ae in db.Passers
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Passer> AEList = null;

                foreach (Passer ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Passer AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Passer record = db.Passers.Single(x => x.id == AE.id);
                Guid g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Passer AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                db.Passers.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Passer AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Passer record = db.Passers.Single(x => x.id == AE.id);
                db.Passers.Remove(record);
                db.SaveChanges();
                return;
            }
        }
    }

    class StoreDAO
    {
        ////////// Stores //////////
        public static List<Stores> LoadAllStores()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                // Define a LinQ Query
                var query = from ae in db.Stores
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Stores> AEList = null;

                foreach (Stores ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Stores AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Stores record = db.Stores.Single(x => x.id == AE.id);
                Guid g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Stores AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                db.Stores.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Stores AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckTrackerContext("CheckTrackerConnectionString"))
            {
                Stores record = db.Stores.Single(x => x.id == AE.id);
                db.Stores.Remove(record);
                db.SaveChanges();
                return;
            }
        }

    } // CheckDAO
} // namespace Checktracker
