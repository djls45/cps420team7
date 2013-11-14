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
    public partial class CheckDialog : Form
    {
        public CheckDialog()
        {
            InitializeComponent();
            LoadPassers();
            LoadAddresses();
            LoadAccounts();
        }

        private void LoadPassers()
        {
            List<Passer> LA = CheckDAO.LoadAllPassers();
            PasserChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Passer a in LA)
                {
                    PasserChoice.Items.Add(a);
                }
            }
            PasserChoice.Items.Insert(0, "-- Create New --");
            PasserChoice.SelectedIndex = 0;
        }

        private void LoadAddresses()
        {
            List<Address> LA = CheckDAO.LoadAllAddresses();
            AddressChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Address a in LA)
                {
                    AddressChoice.Items.Add(a);
                }
            }
            AddressChoice.Items.Insert(0, "-- Create New --");
            AddressChoice.SelectedIndex = 0;
        }

        private void LoadAccounts()
        {
            List<Account> LA = CheckDAO.LoadAllAccounts();
            AccountChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Account a in LA)
                {
                    AccountChoice.Items.Add(a);
                }
            }
            AccountChoice.Items.Insert(0, "-- Create New --");
            AccountChoice.SelectedIndex = 0;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnEditPasser_Click(object sender, EventArgs e)
        {
            PasserDialog pd;
            if (PasserChoice.SelectedIndex != 0)
            {
                pd = new PasserDialog((Passer)PasserChoice.SelectedItem);
            }
            else
            {
                pd = new PasserDialog();
            }
            if (pd.ShowDialog() == DialogResult.OK)
            {
                CheckDAO.Update(pd.Passer);
            }
            LoadPassers();
        }

        private void btnEditAddress_Click(object sender, EventArgs e)
        {
            AddressForm af;
            if (AddressChoice.SelectedIndex != 0)
            {
                af = new AddressForm((Address)AddressChoice.SelectedItem);
            }
            else
            {
                af = new AddressForm();
            }
            if (af.ShowDialog() == DialogResult.OK)
            {
                CheckDAO.Update(af.Address);
            }
            LoadAddresses();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            AccountForm af;
            if (AccountChoice.SelectedIndex != 0)
            {
                af = new AccountForm((Account)AccountChoice.SelectedItem);
            }
            else
            {
                af = new AccountForm();
            }
            if (af.ShowDialog() == DialogResult.OK)
            {
                CheckDAO.Update(af.Account);
            }
            LoadAccounts();
        }

    }
}
