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
    public partial class AddressForm : Form
    {
        public Address Address;

        public AddressForm()
        {
            InitializeComponent();
            Address = new Address();
        }

        public AddressForm(Address addr)
        {
            InitializeComponent();
            Address = addr;
        }

        new public DialogResult ShowDialog()
        {
            addressBox.Text = Address.Street;
            aptBox.Text = Address.AptNo;
            cityBox.Text = Address.City;
            stateBox.Text = Address.State;
            postalBox.Text = Address.PostalCode;
            return base.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Address.Street = addressBox.Text;
            Address.AptNo = aptBox.Text;
            Address.City = cityBox.Text;
            Address.State = stateBox.Text;
            Address.PostalCode = postalBox.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
