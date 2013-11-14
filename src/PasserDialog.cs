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
    public partial class PasserDialog : Form
    {
        public Passer Passer;

        public PasserDialog()
        {
            InitializeComponent();
            Passer = new Passer();
            LoadAddresses();
            AddressChoice.SelectedIndex = 0;
        }

        public PasserDialog(Passer p)
        {
            InitializeComponent();
            Passer = p;
            firstNameBox.Text = p.FName;
            lastNameBox.Text = p.LName;
            LoadAddresses();
            AddressChoice.SelectedIndex = 0;
        }

        new public DialogResult ShowDialog()
        {
            firstNameBox.Text = Passer.FName;
            lastNameBox.Text = Passer.LName;
            return base.ShowDialog();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Passer.FName = firstNameBox.Text;
            Passer.LName = lastNameBox.Text;
            Passer.Address = ((Address)AddressChoice.SelectedItem).id;
            this.DialogResult = DialogResult.OK;
            this.Close();
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
                //CheckDAO.Update(af.Address);
            }
            LoadAddresses();
        }
    }
}
