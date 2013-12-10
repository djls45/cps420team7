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
        public Check check;
        public Employee employee;

        public CheckDialog()
        {
            InitializeComponent();
            SetupComboboxes();
            check = new Check();
        }

        public CheckDialog(Check c)
        {
            InitializeComponent();
            SetupComboboxes();
            check = c;
            LoadCheckData();
        }

        private void SetupComboboxes()
        {
            LoadAddresses();
            LoadAccounts();
            StatusChoice.SelectedIndex = 0;
        }

        private void LoadCheckData()
        {
            amountBox.Text = check.Amount.ToString();
            checkNumBox.Text = check.CheckNum;
            LongAmountText.Text = check.AmountLong;
            imageFileBox.Text = check.ImageFile;
            recipientBox.Text = check.Recipient;
            CheckDatePicker.Value = check.DateWritten;
            for (int i = 1; i < AccountChoice.Items.Count; ++i)
            {
                if (((Account)AccountChoice.Items[i]).id == check.Account)
                {
                    AccountChoice.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 1; i < AddressChoice.Items.Count; ++i)
            {
                if (((Address)AddressChoice.Items[i]).id == check.Address)
                {
                    AddressChoice.SelectedIndex = i;
                    break;
                }
            }
            switch (check.Status)
            {
                case "1":
                    StatusChoice.SelectedIndex = 0;
                    break;
                case "2":
                    StatusChoice.SelectedIndex = 1;
                    break;
                case "3":
                    StatusChoice.SelectedIndex = 2;
                    break;
                case "P":
                    StatusChoice.SelectedIndex = 3;
                    break;
                case "D":
                    StatusChoice.SelectedIndex = 4;
                    break;
                default: break;
            }
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
            AddressChoice.SelectedIndex = 0;
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
            AccountChoice.SelectedIndex = 0;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            check.CheckNum = checkNumBox.Text;
            check.Amount = Convert.ToDecimal(amountBox.Text);
            check.AmountLong = LongAmountText.Text;
            check.Status = ((string)StatusChoice.SelectedItem)[0].ToString();
            check.Recipient = recipientBox.Text;
            check.ImageFile = imageFileBox.Text;
            check.DateWritten = CheckDatePicker.Value;
            check.Address = ((Address)AddressChoice.SelectedItem).id;
            check.Account = ((Account)AccountChoice.SelectedItem).id;
            check.DateEntered = DateTime.Now;

            check.Employee = employee.id;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
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
            for (int i = 1; i < AddressChoice.Items.Count; ++i)
            {
                if (((Address)AddressChoice.Items[i]).id == af.Address.id)
                {
                    AddressChoice.SelectedIndex = i;
                    break;
                }
            }
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
            for (int i = 1; i < AccountChoice.Items.Count; ++i)
            {
                if (((Account)AccountChoice.Items[i]).id == af.Account.id)
                {
                    AccountChoice.SelectedIndex = i;
                    break;
                }
            }
        }

    }
}
