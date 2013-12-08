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
    public partial class DatePicker : Form
    {
        public DateTime from, to;

        public DatePicker()
        {
            InitializeComponent();
        }

        public DatePicker(DateTime f, DateTime t)
        {
            InitializeComponent();
            from = f;
            to = t;
            dateTimePicker1.Value = from;
            dateTimePicker2.Value = to;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            from = dateTimePicker1.Value;
            to = dateTimePicker2.Value;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
