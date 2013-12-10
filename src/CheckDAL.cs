using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace CheckTracker
{
    public class CheckContext : DbContext
    {
        public CheckContext() : base()
        {
            Database.SetInitializer<CheckContext>(new DbInitializer());
        }

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

    class DbInitializer : DropCreateDatabaseIfModelChanges<CheckContext>
                        //DropCreateDatabaseAlways<CheckContext>
    {
        protected override void Seed(CheckContext db)
        {
            Login l1 = new Login()
            {
                Username = "Administrator",
                Password = "admin",
                Date = DateTime.Now
            };
            db.Logins.Add(l1);
            Login l2 = new Login()
            {
                Username = "Manager",
                Password = "manager",
                Date = DateTime.Now
            };
            db.Logins.Add(l2);
            Login l3 = new Login()
            {
                Username = "User",
                Password = "user",
                Date = DateTime.Now
            };
            db.Logins.Add(l3);
            db.SaveChanges();
            l1 = LoginDAO.FindLogin("Administrator");
            Employee emp1 = new Employee()
            {
                FName = "Administrator",
                LName = "Administrator",
                Type = "A",
                Supervisor = null,
                Store = null,
                Login = l1.id
            };
            db.Employees.Add(emp1);

            Forms set = new Forms()
            {
                Letter1 = "{{ADDRESS}}\n\n{{DATE}}\n\n{{FNAME}} {{LNAME}}:\n\n" +
"Check number {{CHECKNUM}} written for the amount of ${{AMOUNT}} on your account at {{BANK}} bounced on {{CHECKDATE}}. There has been a ${{FEEAMT}} collection fee added to the required payment. Please bring a cash payment of {{AMOUNT+FEE}} in to {{STORE}} to cover the check.\n\n" +
"{{MANAGER}}\n{{STORE}}",
                Letter2 = "{{ADDRESS}}\n\n{{DATE}}\n\n{{FNAME}} {{LNAME}}:\n\n" +
"WARNING: THIS IS YOUR TWO-WEEK NOTICE.\n\n" +
"Payment for check number {{CHECKNUM}} written on {{CHECKDATE}} for the amount of ${{AMOUNT}} on account {{ACCOUNT}} at {{BANK}} was rejected and a fee of ${{FEEAMT}} was assessed to your account. Please bring a cash payment to the amount of ${{AMOUNT+FEE}} to {{STORE}} to cover the check payment.\n\n" +
"{{MANAGER}}\n{{STORE}}",
                Letter3 = "{{ADDRESS}}\n\n{{DATE}}\n\n{{FNAME}} {{LNAME}}:\n\n" +
"Unfortunately, since we have received insufficient payment to cover your check (check number {{CHECKNUM}} on account {{ACCOUNT}} at {{BANK}} for ${{AMOUNT}}), we have initiated court proceedings to collect the amount of the check plus a legal collection fee of ${{FEEAMT}}. You will also receive a court notice with the date, time, and location of the hearing.\n\n" +
"{{MANAGER}}\n{{STORE}}",
                Regulations = "",
                Notices = ""
            };
            db.Forms.Add(set);
            Configuration config = new Configuration()
            {
                FeeAmt = 25.00m
            };
            db.Configurations.Add(config);
            Address addr = new Address()
            {
                Street = "123 Easy St",
                AptNo = "A",
                City = "Anywhere",
                State = "AK",
                Country = "USA",
                PostalCode = "12345",
                Phone = "(234)567-8910"
            };
            db.Addresses.Add(addr);
            db.SaveChanges();
            set = FormsDAO.LoadAllForms().First();
            config = ConfigDAO.LoadAllConfigs().First();
            addr = AddressDAO.LoadAllAddresses().First();
            Stores store = new Stores()
            {
                Name = "Test Store",
                Form = set.id,
                Configuration = config.id,
                Location = addr.id
            };
            db.Stores.Add(store);
            db.SaveChanges();
            store = StoreDAO.LoadAllStores().Find(x => x.Name == "Test Store");
            l2 = LoginDAO.FindLogin("Manager");
            Employee emp2 = new Employee()
            {
                FName = "Manager",
                LName = "Manager",
                Type = "M",
                Supervisor = null,
                Store = store.id,
                Login = l2.id
            };
            db.Employees.Add(emp2);
            db.SaveChanges();
            emp2 = EmployeeDAO.LoadAllEmployees().Find(x => x.LName == "Manager");
            l3 = LoginDAO.FindLogin("User");
            Employee emp3 = new Employee()
            {
                FName = "User",
                LName = "User",
                Type = "U",
                Supervisor = emp2.id,
                Store = store.id,
                Login = l3.id
            };
            db.Employees.Add(emp3);
            db.SaveChanges();
            
            base.Seed(db);
        }
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

        public static List<Check> LoadAllCurrentChecks()
        {
            using (CheckContext cc = new CheckContext())
            {
                List<Check> LC = new List<Check>();
                var query = from xs in cc.Checks
                            where xs.Status != "D" //deleted
                               && xs.Status != "P" //paid
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
                Check ch = cc.Checks.SingleOrDefault(x => x.id == c.id);
                ch = c;
                cc.SaveChanges();
            }
        }

        public static void Delete(Check c)
        {
            using (CheckContext cc = new CheckContext())
            {
                Check ch = cc.Checks.SingleOrDefault(x => x.id == c.id);
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
            
            using (var db = new CheckContext())
            {
                Account record = db.Accounts.SingleOrDefault(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Account AE)
        {
            
            using (var db = new CheckContext())
            {
                db.Accounts.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Account AE)
        {
            
            using (var db = new CheckContext())
            {
                Account record = db.Accounts.SingleOrDefault(x => x.id == AE.id);
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
            
            using (var db = new CheckContext())
            {
                Address record = db.Addresses.SingleOrDefault(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Address AE)
        {
            
            using (var db = new CheckContext())
            {
                db.Addresses.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Address AE)
        {
            
            using (var db = new CheckContext())
            {
                Address record = db.Addresses.SingleOrDefault(x => x.id == AE.id);
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
            
            using (var db = new CheckContext())
            {
                Bank record = db.Banks.SingleOrDefault(x => x.RoutingNum == AE.RoutingNum);
                string id = record.RoutingNum;
                record = AE;
                record.RoutingNum = id;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Bank AE)
        {
            
            using (var db = new CheckContext())
            {
                db.Banks.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Bank AE)
        {
            
            using (var db = new CheckContext())
            {
                Bank record = db.Banks.SingleOrDefault(x => x.RoutingNum == AE.RoutingNum);
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
            
            using (var db = new CheckContext())
            {
                Configuration record = db.Configurations.SingleOrDefault(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Configuration AE)
        {
            
            using (var db = new CheckContext())
            {
                db.Configurations.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Configuration AE)
        {
            
            using (var db = new CheckContext())
            {
                Configuration record = db.Configurations.SingleOrDefault(x => x.id == AE.id);
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

        public static Employee FindEmployee(int EmpID)
        {
            using(var db = new CheckContext())
            {
                List<Employee> le = new List<Employee>();
                var query = from ae in db.Employees
                            where ae.id == EmpID
                            select ae;
                var results = query.ToList();
                foreach (Employee e in results)
                    le.Add(e);
                return le.First();
            }
        }

        public static void Update(Employee AE)
        {
            
            using (var db = new CheckContext())
            {
                Employee record = db.Employees.SingleOrDefault(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Employee AE)
        {
            
            using (var db = new CheckContext())
            {
                db.Employees.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Employee AE)
        {
            
            using (var db = new CheckContext())
            {
                Employee record = db.Employees.SingleOrDefault(x => x.id == AE.id);
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
            
            using (var db = new CheckContext())
            {
                Forms record = db.Forms.SingleOrDefault(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Forms AE)
        {
            
            using (var db = new CheckContext())
            {
                db.Forms.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Forms AE)
        {
            
            using (var db = new CheckContext())
            {
                Forms record = db.Forms.SingleOrDefault(x => x.id == AE.id);
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
                var query = from l in db.Logins
                            where l.Username == username
                            select l;
                List<Login> ll = new List<Login>();
                foreach (Login l in query)
                {
                    ll.Add(l);
                }
                ll.OrderByDescending(t => t.Date);
                Login login = ll.FirstOrDefault();
                return login;
            }
        }

        public static Login FindLogin(int? id)
        {
            using (var db = new CheckContext())
            {
                var query = from l in db.Logins
                            where l.id == id
                            select l;
                List<Login> ll = new List<Login>();
                foreach (Login l in query)
                {
                    ll.Add(l);
                }
                Login login = ll.FirstOrDefault();
                return login;
            }
        }

        public static void Update(Login AE)
        {
            using (var db = new CheckContext())
            {
                Login record = db.Logins.SingleOrDefault(x => x.id == AE.id);
                record = AE;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Login AE)
        {
            
            using (var db = new CheckContext())
            {
                AE.Date = DateTime.Now;
                db.Logins.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Login AE)
        {
            
            using (var db = new CheckContext())
            {
                Login record = db.Logins.SingleOrDefault(x => x.id == AE.id);
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
            
            using (var db = new CheckContext())
            {
                Passer record = db.Passers.SingleOrDefault(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Passer AE)
        {
            
            using (var db = new CheckContext())
            {
                db.Passers.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Passer AE)
        {
            
            using (var db = new CheckContext())
            {
                Passer record = db.Passers.SingleOrDefault(x => x.id == AE.id);
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
            
            using (var db = new CheckContext())
            {
                Stores record = db.Stores.SingleOrDefault(x => x.id == AE.id);
                int g = record.id;
                record = AE;
                record.id = g;
                db.SaveChanges();
                return;
            }
        }

        public static void Create(Stores AE)
        {
            
            using (var db = new CheckContext())
            {
                db.Stores.Add(AE);
                db.SaveChanges();
                return;
            }
        }

        public static void Delete(Stores AE)
        {
            
            using (var db = new CheckContext())
            {
                Stores record = db.Stores.SingleOrDefault(x => x.id == AE.id);
                db.Stores.Remove(record);
                db.SaveChanges();
                return;
            }
        }

    }
}
