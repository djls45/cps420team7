using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckTracker
{
    public partial class AccountForm : Form
    {
        public Account Account;

        public AccountForm()
        {
            InitializeComponent();
            Account = new Account();
            LoadBanks();
            LoadOwners();
        }

        public AccountForm(Account act)
        {
            InitializeComponent();
            Account = act;
            LoadBanks();
            LoadOwners();
            AccountBox.Text = Account.AccountNum;
        }

        private void LoadBanks()
        {
            List<Bank> LA = BankDAO.LoadAllBanks();
            BankChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Bank a in LA)
                {
                    BankChoice.Items.Add(a);
                }
            }
            BankChoice.Items.Insert(0, "-- Create New --");
            BankChoice.SelectedIndex = 0;
        }

        private void LoadOwners()
        {
            List<Passer> LA = PasserDAO.LoadAllPassers();
            OwnerChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Passer a in LA)
                {
                    OwnerChoice.Items.Add(a);
                }
            }
            OwnerChoice.Items.Insert(0, "-- Create New --");
            OwnerChoice.SelectedIndex = 0;
        }

        private void btnEditOwner_Click(object sender, EventArgs e)
        {
            PasserDialog pd;
            if (OwnerChoice.SelectedIndex != 0)
            {
                pd = new PasserDialog((Passer)OwnerChoice.SelectedItem);
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    PasserDAO.Update(pd.Passer);
                }
            }
            else
            {
                pd = new PasserDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    PasserDAO.Create(pd.Passer);
                }
            }
            LoadOwners();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Account.AccountNum = AccountBox.Text;
            Account.Bank = ((Bank)BankChoice.SelectedItem).id;
            Account.Owner = ((Passer)OwnerChoice.SelectedItem).id;
            this.Close();
        }

        private void btnEditBank_Click(object sender, EventArgs e)
        {
            BankForm af;
            if (BankChoice.SelectedIndex != 0)
            {
                af = new BankForm((Bank)BankChoice.SelectedItem);
                if (af.ShowDialog() == DialogResult.OK)
                {
                    BankDAO.Update(af.Bank);
                }
            }
            else
            {
                af = new BankForm();
                if (af.ShowDialog() == DialogResult.OK)
                {
                    BankDAO.Create(af.Bank);
                }
            }
            LoadBanks();
        }
    }
}
