using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace CheckTracker
{
    public class CheckContext : DbContext
    {
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


    public class CheckDAO
    {
        public static List<Check> LoadAllChecks()
        {
            using (CheckContext cc = new CheckContext())
            {
                List<Check> LC = new List<Check>();
                var query = from xs in cc.Checks
                            select xs;
                var result = query.ToList();
                foreach (Check c in result)
                {
                    //if(c.Status != 'D')
                        LC.Add(c);
                }
                return LC;
            }
        }

        public static void Create(Check c)
        {
            using (CheckContext cc = new CheckContext())
            {
                cc.Checks.Add(c);
                cc.SaveChanges();
            }
        }

        public static void Update(Check c)
        {
            using (CheckContext cc = new CheckContext())
            {
                Check ch = cc.Checks.Single(x => x.id == c.id);
                ch = c;
                cc.SaveChanges();
            }
        }

        public static void Delete(Check c)
        {
            using (CheckContext cc = new CheckContext())
            {
                Check ch = cc.Checks.Single(x => x.id == c.id);
                cc.Checks.Remove(ch);
                cc.SaveChanges();
            }
        }

    }


    class AccountDAO
    {
        ////////// Accounts //////////
        public static List<Account> LoadAllAccounts()
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                // Define a LinQ Query
                var query = from ae in db.Accounts
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Account> AEList = new List<Account>();

                foreach (Account ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Account AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                Account record = db.Accounts.Single(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Account AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                db.Accounts.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Account AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
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
            using (var db = new CheckContext())
            {
                // Define a LinQ Query
                var query = from ae in db.Addresses
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Address> AEList = new List<Address>();

                foreach (Address ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Address AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                Address record = db.Addresses.Single(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Address AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                db.Addresses.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Address AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
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
            using (var db = new CheckContext())
            {
                // Define a LinQ Query
                var query = from ae in db.Banks
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Bank> AEList = new List<Bank>();

                foreach (Bank ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Bank AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
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
            using (var db = new CheckContext())
            {
                db.Banks.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Bank AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
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
            using (var db = new CheckContext())
            {
                // Define a LinQ Query
                var query = from ae in db.Configurations
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Configuration> AEList = new List<Configuration>();

                foreach (Configuration ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Configuration AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                Configuration record = db.Configurations.Single(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Configuration AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                db.Configurations.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Configuration AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
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
            using (var db = new CheckContext())
            {
                // Define a LinQ Query
                var query = from ae in db.Employees
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Employee> AEList = new List<Employee>();

                foreach (Employee ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Employee AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                Employee record = db.Employees.Single(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Employee AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                db.Employees.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Employee AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
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
            using (var db = new CheckContext())
            {
                // Define a LinQ Query
                var query = from ae in db.Forms
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Forms> AEList = new List<Forms>();

                foreach (Forms ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Forms AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                Forms record = db.Forms.Single(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Forms AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                db.Forms.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Forms AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
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
            using (var db = new CheckContext())
            {
                // Define a LinQ Query
                var query = from ae in db.Logins
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Login> AEList = new List<Login>();

                foreach (Login ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static Login FindLogin(string username)
        {
            using (var db = new CheckContext())
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
            using (var db = new CheckContext())
            {
                Login record = db.Logins.Single(x => x.id == AE.id);
                //AE.Date = DateTime.Now;
                //AE.id = int.Newint();
                //db.Logins.Add(AE);
                record = AE;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Login AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                db.Logins.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Login AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
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
            using (var db = new CheckContext())
            {
                // Define a LinQ Query
                var query = from ae in db.Passers
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Passer> AEList = new List<Passer>();

                foreach (Passer ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Passer AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                Passer record = db.Passers.Single(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Passer AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                db.Passers.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Passer AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
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
            using (var db = new CheckContext())
            {
                // Define a LinQ Query
                var query = from ae in db.Stores
                            select ae;

                // Execute the query
                var results = query.ToList();
                List<Stores> AEList = new List<Stores>();

                foreach (Stores ae in results)
                    AEList.Add(ae);

                return AEList;
            }
        }

        public static void Update(Stores AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                Stores record = db.Stores.Single(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Stores AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                db.Stores.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Stores AE)
        {
            // "server=localhost;database=AddressBook;"
            using (var db = new CheckContext())
            {
                Stores record = db.Stores.Single(x => x.id == AE.id);
                db.Stores.Remove(record);
                db.SaveChanges();
                return;
            }
        }

    }
}
