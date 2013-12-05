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
    public partial class EmployeeForm : Form
    {
        public Employee Employee;

        public EmployeeForm()
        {
            InitializeComponent();
            LoadSupervisors();
            SupervisorChoice.SelectedIndex = 0;
            LoadStores();
            StoreChoice.SelectedIndex = 0;
            TypeChoice.SelectedIndex = 0;
        }

        public EmployeeForm(Employee e)
        {
            InitializeComponent();
            Employee = e;
            LoadSupervisors();
            SupervisorChoice.SelectedIndex = 0;
            LoadStores();
            StoreChoice.SelectedIndex = 0;
            TypeChoice.SelectedIndex = 0;
        }

        private void LoadSupervisors()
        {
            List<Employee> LA = EmployeeDAO.LoadAllEmployees();
            SupervisorChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Employee a in LA)
                {
                    SupervisorChoice.Items.Add(a);
                }
            }
            SupervisorChoice.Items.Insert(0, "-- Create New --");
        }

        private void LoadStores()
        {
            List<Stores> LA = StoreDAO.LoadAllStores();
            StoreChoice.Items.Clear();
            if (LA != null)
            {
                foreach (Stores a in LA)
                {
                    StoreChoice.Items.Add(a);
                }
            }
            StoreChoice.Items.Insert(0, "-- Create New --");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Employee.FName = FNameBox.Text;
            Employee.LName = LNameBox.Text;
            Employee.Type = TypeChoice.SelectedItem.ToString()[0].ToString();
            Employee.Supervisor = ((Employee)SupervisorChoice.SelectedItem).id;
            Employee.Store = ((Stores)StoreChoice.SelectedItem).id;
            Employee.Login = null;

            if (UsernameBox.TextLength > 0)
            {
                Login login;
                if(Password1Box.Text == Password2Box.Text)
                {
                    login = new Login()
                    {
                        Username = UsernameBox.Text,
                        Password = Password1Box.Text,
                        Date = DateTime.Now
                    };
                    LoginDAO.Create(login);
                    login = LoginDAO.FindLogin(UsernameBox.Text);
                    Employee.Login = login.id;
                }
                else
                {
                    MessageBox.Show("The passwords do not match.", 
                                    "Password Error", MessageBoxButtons.OK);
                    return;
                }
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnEditSupervisor_Click(object sender, EventArgs e)
        {
            EmployeeForm ef;
            if (SupervisorChoice.SelectedIndex != 0)
            {
                ef = new EmployeeForm((Employee)SupervisorChoice.SelectedItem);
                if (ef.ShowDialog() == DialogResult.OK)
                {
                    EmployeeDAO.Update(ef.Employee);
                }
            }
            else
            {
                ef = new EmployeeForm();
                if (ef.ShowDialog() == DialogResult.OK)
                {
                    EmployeeDAO.Create(ef.Employee);
                }
            }
            LoadSupervisors();
        }

        private void btnEditStore_Click(object sender, EventArgs e)
        {
            StoreForm sf;
            if (StoreChoice.SelectedIndex != 0)
            {
                sf = new StoreForm((Stores)StoreChoice.SelectedItem);
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    StoreDAO.Update(sf.Store);
                }
            }
            else
            {
                sf = new StoreForm();
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    StoreDAO.Create(sf.Store);
                }
            }
            LoadStores();
        }
    }
}
