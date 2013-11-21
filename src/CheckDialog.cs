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
        public Check Check;

        public CheckDialog()
        {
            InitializeComponent();
            LoadPassers();
            PasserChoice.SelectedIndex = 0;
            LoadAddresses();
            AddressChoice.SelectedIndex = 0;
            LoadAccounts();
            AccountChoice.SelectedIndex = 0;
            Check = new Check();
            LoadCheckData();
        }

        public CheckDialog(Check c)
        {
            InitializeComponent();
            LoadPassers();
            PasserChoice.SelectedIndex = 0;
            LoadAddresses();
            AddressChoice.SelectedIndex = 0;
            LoadAccounts();
            AccountChoice.SelectedIndex = 0;
            Check = c;
            LoadCheckData();
        }

        private void LoadCheckData()
        {
            amountBox.Text = Check.Amount.ToString();
            checkNumBox.Text = Check.CheckNum;
            LongAmountText.Text = Check.AmountLong;
            imageFileBox.Text = Check.ImageFile;
            recipientBox.Text = Check.Recipient;

            //comboboxes...
        }

        private void LoadPassers()
        {
            List<Passer> LA = PasserDAO.LoadAllPassers();
            PasserChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Passer a in LA)
                {
                    PasserChoice.Items.Add(a);
                }
            }
            PasserChoice.Items.Insert(0, "-- Create New --");
        }

        private void LoadAddresses()
        {
            List<Address> LA = AddressDAO.LoadAllAddresses();
            AddressChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Address a in LA)
                {
                    AddressChoice.Items.Add(a);
                }
            }
            AddressChoice.Items.Insert(0, "-- Create New --");
        }

        private void LoadAccounts()
        {
            List<Account> LA = AccountDAO.LoadAllAccounts();
            AccountChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Account a in LA)
                {
                    AccountChoice.Items.Add(a);
                }
            }
            AccountChoice.Items.Insert(0, "-- Create New --");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Check.CheckNum = checkNumBox.Text;
            Check.Amount = Convert.ToDecimal(amountBox.Text);
            Check.AmountLong = LongAmountText.Text;
            Check.Recipient = recipientBox.Text;
            Check.ImageFile = imageFileBox.Text;

            //comboboxes...

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
            LoadPassers();
        }

        private void btnEditAddress_Click(object sender, EventArgs e)
        {
            AddressForm af;
            if (AddressChoice.SelectedIndex != 0)
            {
                af = new AddressForm((Address)AddressChoice.SelectedItem);
                if (af.ShowDialog() == DialogResult.OK)
                {
                    AddressDAO.Update(af.Address);
                }
            }
            else
            {
                af = new AddressForm();
                if (af.ShowDialog() == DialogResult.OK)
                {
                    AddressDAO.Create(af.Address);
                }
            }
            LoadAddresses();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            AccountForm af;
            if (AccountChoice.SelectedIndex != 0)
            {
                af = new AccountForm((Account)AccountChoice.SelectedItem);
                if (af.ShowDialog() == DialogResult.OK)
                {
                    AccountDAO.Update(af.Account);
                }
            }
            else
            {
                af = new AccountForm();
                if (af.ShowDialog() == DialogResult.OK)
                {
                    AccountDAO.Create(af.Account);
                }
            }
            LoadAccounts();
        }

    }
}
