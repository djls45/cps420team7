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
    public partial class StoreForm : Form
    {
        public Stores Store;
        
        public StoreForm()
        {
            InitializeComponent();
            LoadAddresses();
            LoadConfigurations();
            LoadForms();
        }

        public StoreForm(Stores store)
        {
            InitializeComponent();
            LoadAddresses();
            LoadConfigurations();
            LoadForms();
            Store = store;
            for (int i = 1; i < AddressChoice.Items.Count; ++i)
            {
                if (((Address)AddressChoice.Items[i]).id == Store.Location)
                {
                    AddressChoice.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 1; i < ConfigChoice.Items.Count; ++i)
            {
                if (((Configuration)ConfigChoice.Items[i]).id == Store.Configuration)
                {
                    ConfigChoice.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 1; i < FormsChoice.Items.Count; ++i)
            {
                if (((Forms)ConfigChoice.Items[i]).id == Store.Form)
                {
                    FormsChoice.SelectedIndex = i;
                    break;
                }
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

        private void LoadConfigurations()
        {
            List<Configuration> LA = ConfigDAO.LoadAllConfigs();
            ConfigChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Configuration a in LA)
                {
                    ConfigChoice.Items.Add(a);
                }
            }
            ConfigChoice.Items.Insert(0, "-- Create New --");
            ConfigChoice.SelectedIndex = 0;
        }

        private void LoadForms()
        {
            List<Forms> LA = FormsDAO.LoadAllForms();
            FormsChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Forms a in LA)
                {
                    FormsChoice.Items.Add(a);
                }
            }
            FormsChoice.Items.Insert(0, "-- Create New --");
            FormsChoice.SelectedIndex = 0;
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

        private void btnEditConfig_Click(object sender, EventArgs e)
        {
            ConfigForm af;
            if (ConfigChoice.SelectedIndex != 0)
            {
                af = new ConfigForm((Configuration)ConfigChoice.SelectedItem);
                if (af.ShowDialog() == DialogResult.OK)
                {
                    ConfigDAO.Update(af.Config);
                }
            }
            else
            {
                af = new ConfigForm();
                if (af.ShowDialog() == DialogResult.OK)
                {
                    ConfigDAO.Create(af.Config);
                }
            }
            LoadConfigurations();
            for (int i = 1; i < ConfigChoice.Items.Count; ++i)
            {
                if (((Configuration)ConfigChoice.Items[i]).id == af.Config.id)
                {
                    ConfigChoice.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnEditForms_Click(object sender, EventArgs e)
        {
            FormsForm af;
            if (AddressChoice.SelectedIndex != 0)
            {
                af = new FormsForm((Forms)AddressChoice.SelectedItem);
                if (af.ShowDialog() == DialogResult.OK)
                {
                    FormsDAO.Update(af.FormSet);
                }
            }
            else
            {
                af = new FormsForm();
                if (af.ShowDialog() == DialogResult.OK)
                {
                    FormsDAO.Create(af.FormSet);
                }
            }
            LoadForms();
            for (int i = 1; i < FormsChoice.Items.Count; ++i)
            {
                if (((Forms)ConfigChoice.Items[i]).id == af.FormSet.id)
                {
                    FormsChoice.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Store.Name = NameBox.Text;
            if (AddressChoice.SelectedIndex != 0)
            {
                Store.Location = ((Address)AddressChoice.SelectedItem).id;
            }
            else
            {
                Store.Location = null;
            }

            if (ConfigChoice.SelectedIndex != 0)
            {
                Store.Configuration = ((Configuration)ConfigChoice.SelectedItem).id;
            }
            else
            {
                MessageBox.Show("You must select a configuration for this store.",
                                "Invalid Configuration", MessageBoxButtons.OK);
                return;
            }

            if (FormsChoice.SelectedIndex != 0)
            {
                Store.Form = ((Forms)FormsChoice.SelectedItem).id;
            }
            else
            {
                MessageBox.Show("You must select a form set for this store.",
                                "Invalid Form Set", MessageBoxButtons.OK);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
