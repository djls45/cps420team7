using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Printing;

namespace CheckTracker
{
    public partial class MainForm : Form
    {
        public Employee currentUser;
        public Login login;
        public LoginDialog logindlg;
        private PrintDocument printDoc;
        private string FormLetter;

        public MainForm()
        {
            InitializeComponent();
            printDoc = new PrintDocument();
            printDoc.PrintPage += PrintCheckLetter;
        }

        private void LoadChecks()
        {
            List<Check> LC;
            if (currentUser != null)
            {
                switch (currentUser.Type)
                {
                    case "A": // administrator
                        LC = CheckDAO.LoadAllChecks();
                        break;
                    case "M": // manager
                    case "U": // user
                        LC = CheckDAO.LoadAllCurrentChecks();
                        break;
                    default: // do nothing
                        LC = new List<Check>();
                        break;
                }
                CheckDataGrid.DataSource = LC;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load size and location from config file and set form
            //this.Size = Properties.Settings.Default.MainFormSize;
            //this.Location = Properties.Settings.Default.MainFormLocation;

            LoadChecks();
            CheckDataGrid.AutoResizeColumns();
        }

        private void MenuCreateCheck(object sender, EventArgs e)
        {
            CheckDialog cd = new CheckDialog();
            cd.employee = currentUser;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                CheckDAO.Create(cd.check);
                LoadChecks();
            }
        }

        private void MenuUpdateCheck(object sender, EventArgs e)
        {
            Check ch = (Check)CheckDataGrid.CurrentRow.DataBoundItem;
            if (ch == null)
            {
                MessageBox.Show("Please select a row to edit and try again.", 
                                "No Row Selected", MessageBoxButtons.OK);
            }
            else
            {
                CheckDialog cd = new CheckDialog(ch);
                cd.employee = currentUser;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    CheckDAO.Update(cd.check);
                    LoadChecks();
                }
            }
        }

        private void MenuDeleteCheck(object sender, EventArgs e)
        {
            //get selected check entry
            Check ch = (Check)CheckDataGrid.CurrentRow.DataBoundItem;
            if (ch == null)
            {
                MessageBox.Show("Please select a row to delete and try again.",
                                "No Row Selected", MessageBoxButtons.OK);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this record?",
                    "Confirm Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    switch (currentUser.Type)
                    {
                        case "A": // administrator
                            //delete
                            CheckDAO.Delete(ch);
                            break;
                        case "M": // manager
                        case "U": // user
                            //set status to "D"
                            ch.Status = "D";
                            CheckDAO.Update(ch);
                            break;
                        default: // do nothing
                            break;
                    }//switch
                    LoadChecks();
                }//if user wants to delete
            }//if check exists
        }//menu item: delete check

        private void MenuChecksHistory(object sender, EventArgs e)
        {
            HistoryForm history = new HistoryForm();
            history.ShowDialog();
        }

        // Save window location to user config file when it is moved on the screen
        /*private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainFormLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        // When the window size is changed, save to user config file
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainFormSize = this.Size;
            Properties.Settings.Default.Save();
        }*/

        //logout
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logindlg.Show();
        }

        private void MenuCreateEmployee(object sender, EventArgs e)
        {
            EmployeeForm ef = new EmployeeForm();
            if (ef.ShowDialog() == DialogResult.OK)
            {
                EmployeeDAO.Create(ef.Employee);
            }
        }

        private void MenuCreateStore(object sender, EventArgs e)
        {
            StoreForm sf = new StoreForm();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                StoreDAO.Create(sf.Store);
            }
        }

        private void MenuChangePassword(object sender, EventArgs e)
        {
            LoginUpdateForm luf = new LoginUpdateForm(login);
            if (luf.ShowDialog() == DialogResult.OK)
            {
                LoginDAO.Create(luf.login);
            }
        }

        private void HandleDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore data errors in table view
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string about = "CheckTracker was developed " +
                           "in the fall of 2013 by\n\n" +
                           "\tJed Schaaf\n" +
                           "\tJosiah Rickerd\n" +
                           "\tand Jason McVey\n\n" +
                           "for CpS 420 - Software Development\n" +
                           "at Bob Jones Univeristy";
            MessageBox.Show(about, "About CheckTracker", MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuPrintAllChecks(object sender, EventArgs e)
        {
            PrintCheckDialog.Document = printDoc;
            if (PrintCheckDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc = PrintCheckDialog.Document;
                List<Check> LC = CheckDAO.LoadAllCurrentChecks().
                    FindAll(x => x.DateEntered.Date == DateTime.Today);
                foreach (Check c in LC)
                {
                    GetLetter(c);
                    printDoc.Print();
                }
                LC = CheckDAO.LoadAllCurrentChecks().
                    FindAll(x => x.DateEntered.Date.AddDays(14) == DateTime.Today &&
                                 x.Status == "1");
                foreach (Check c in LC)
                {
                    c.Status = "2";
                    GetLetter(c);
                    printDoc.Print();
                    CheckDAO.Update(c);
                }
                LC = CheckDAO.LoadAllCurrentChecks().
                    FindAll(x => x.DateEntered.Date.AddDays(28) == DateTime.Today &&
                                 x.Status == "2");
                foreach (Check c in LC)
                {
                    c.Status = "3";
                    GetLetter(c);
                    printDoc.Print();
                    CheckDAO.Update(c);
                }
            }
        }

        private void MenuPrintP1Checks(object sender, EventArgs e)
        {
            PrintCheckDialog.Document = printDoc;
            if (PrintCheckDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc = PrintCheckDialog.Document;
                List<Check> LC = CheckDAO.LoadAllCurrentChecks().
                    FindAll(x => x.DateEntered.Date == DateTime.Today && 
                                 x.Status == "1");
                foreach (Check c in LC)
                {
                    GetLetter(c);
                    printDoc.Print();
                    CheckDAO.Update(c);
                }
            }
        }

        private void MenuPrintP2Checks(object sender, EventArgs e)
        {
            PrintCheckDialog.Document = printDoc;
            if (PrintCheckDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc = PrintCheckDialog.Document;
                List<Check> LC = CheckDAO.LoadAllCurrentChecks().
                    FindAll(x => x.DateEntered.Date.AddDays(14) <= DateTime.Today &&
                                 x.Status == "1");
                foreach (Check c in LC)
                {
                    c.Status = "2";
                    GetLetter(c);
                    printDoc.Print();
                    CheckDAO.Update(c);
                }
            }
        }

        private void MenuPrintP3Checks(object sender, EventArgs e)
        {
            PrintCheckDialog.Document = printDoc;
            if (PrintCheckDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc = PrintCheckDialog.Document;
                List<Check> LC = CheckDAO.LoadAllCurrentChecks().
                    FindAll(x => x.DateEntered.Date.AddDays(28) <= DateTime.Today &&
                                 x.Status == "2");
                foreach (Check c in LC)
                {
                    c.Status = "3";
                    GetLetter(c);
                    printDoc.Print();
                    CheckDAO.Update(c);
                }
            }
        }

        private void MenuPrintSelectedCheck(object sender, EventArgs e)
        {
            PrintCheckDialog.Document = printDoc;
            Check c = (Check)CheckDataGrid.CurrentRow.DataBoundItem;
            if (PrintCheckDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc = PrintCheckDialog.Document;
                bool update = (((c.DateEntered.Date.AddDays(14) <= DateTime.Today) && (c.Status == "1")) ||
                              ((c.DateEntered.Date.AddDays(28) <= DateTime.Today) && (c.Status == "2")));
                if (update)
                {
                    switch (c.Status)
                    {
                        case "1":
                            c.Status = "2";
                            break;
                        case "2":
                            c.Status = "3";
                            break;
                        default: break;
                    }
                }
                GetLetter(c);
                printDoc.Print();
                if (update)
                {
                    CheckDAO.Update(c);
                }
            }
        }//MenuPrintSelectedCheck

        private void GetLetter(Check c)
        {
            Employee manager;
            if(currentUser.Type == "A" || currentUser.Type == "M")
                manager = currentUser;
            else
            {
                manager = EmployeeDAO.FindEmployee(currentUser.Supervisor.Value);
            }
            Account acct = AccountDAO.LoadAllAccounts().Find(a => a.id == c.Account);
            Passer passer = PasserDAO.LoadAllPassers().Find(p => p.id == acct.Owner);
            Address paddr = AddressDAO.LoadAllAddresses().Find(d => d.id == passer.Address);
            Bank bank = BankDAO.LoadAllBanks().Find(b => b.id == acct.Bank);

            Stores store = StoreDAO.LoadAllStores().Find(s => s.id == currentUser.Store);
            Address saddr = AddressDAO.LoadAllAddresses().Find(d => d.id == store.Location);
            Configuration config = ConfigDAO.LoadAllConfigs().Find(cfg => cfg.id == store.Configuration);
            Forms set = FormsDAO.LoadAllForms().Find(f => f.id == store.Location);

            switch (c.Status)
            {
                case "1":
                    FormLetter = set.Letter1;
                    break;
                case "2":
                    FormLetter = set.Letter2;
                    break;
                case "3":
                    FormLetter = set.Letter3;
                    break;
                default: break;
            }//switch
            FormLetter = FormLetter.Replace("{{ADDRESS}}", paddr.ToString())
                                   .Replace("{{DATE}}", DateTime.Now.ToString())
                                   .Replace("{{FNAME}}", passer.FName)
                                   .Replace("{{LNAME}}", passer.LName)
                                   .Replace("{{CHECKNUM}}", c.CheckNum)
                                   .Replace("{{AMOUNT}}", c.Amount.ToString())
                                   .Replace("{{ACCOUNT}}", acct.AccountNum)
                                   .Replace("{{BANK}}", bank.Name)
                                   .Replace("{{CHECKDATE}}", c.DateWritten.ToShortDateString())
                                   .Replace("{{FEEAMT}}", config.FeeAmt.ToString())
                                   .Replace("{{AMOUNT+FEE}}", (c.Amount + config.FeeAmt).ToString())
                                   .Replace("{{STORE}}", store.Name);
            if (manager != null)
            {
                FormLetter = FormLetter.Replace("{{MANAGER}}",
                                                manager.FName + " " +
                                                manager.LName + "\n" +
                                                saddr.ToString());
            }
            else
            {
                FormLetter = FormLetter.Replace("{{MANAGER}}", saddr.ToString());
            }
        }//GetLetter(Check)

        private void PrintCheckLetter(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters  
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(FormLetter, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(FormLetter, this.Font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            FormLetter = FormLetter.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (FormLetter.Length > 0);
        }

    }//class MainForm
    
}//namespace CheckTracker

