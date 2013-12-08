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
    public partial class HistoryForm : Form
    {
        DateTime from, to;
        List<Check> LC;

        public HistoryForm()
        {
            InitializeComponent();
            List<Check> LC = CheckDAO.LoadAllChecks();
            CheckGridView.DataSource = LC;
            from = DateTime.Now;
            to = DateTime.Now;
        }

        private void IndexChangedUpdateView(object sender, EventArgs e)
        {
            string option = ((string)StatusBox.SelectedItem);
            LC = CheckDAO.LoadAllChecks();
            List<Check> chklst = new List<Check>();
            switch (option)
            {
                case "All":
                    foreach (Check c in LC) chklst.Add(c);
                    break;
                case "Phase 1":
                    foreach (Check c in LC) if (c.Status == "1") chklst.Add(c);
                    break;
                case "Phase 2":
                    foreach (Check c in LC) if (c.Status == "2") chklst.Add(c);
                    break;
                case "Phase 3":
                    foreach (Check c in LC) if (c.Status == "3") chklst.Add(c);
                    break;
                case "Paid":
                    foreach (Check c in LC) if (c.Status == "P") chklst.Add(c);
                    break;
                case "Deleted":
                    foreach (Check c in LC) if (c.Status == "D") chklst.Add(c);
                    break;
                default: break;
            }
            CheckGridView.DataSource = chklst;
        }

        private void HandleDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore data errors
        }

        private void selectDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatePicker dp = new DatePicker(from, to);
            if (dp.ShowDialog() == DialogResult.OK)
            {
                from = dp.from;
                to = dp.to;
                foreach (Check c in LC)
                {
                    if (c.DateEntered < dp.from || c.DateEntered > dp.to) LC.Remove(c);
                }
            }
        }

    }

}
