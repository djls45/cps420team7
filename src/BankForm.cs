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
    public partial class BankForm : Form
    {
        public Bank Bank;

        public BankForm()
        {
            InitializeComponent();
            Bank = new Bank();
            LoadAddresses();
        }

        public BankForm(Bank b)
        {
            InitializeComponent();
            Bank = b;
            RoutingNumBox.Text = Bank.RoutingNum;
            NameBox.Text = Bank.Name;
            LoadAddresses();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnEditLocaton_Click(object sender, EventArgs e)
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
    }
}
