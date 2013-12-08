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
    public partial class FormsForm : Form
    {
        public Forms FormSet;

        public FormsForm()
        {
            InitializeComponent();
        }
        
        public FormsForm(Forms formset)
        {
            InitializeComponent();
            FormSet = formset;
            Form1Box.Text = FormSet.Letter1;
            Form2Box.Text = FormSet.Letter2;
            Form3Box.Text = FormSet.Letter3;
            RegsBox.Text = FormSet.Regulations;
            NoticesBox.Text = FormSet.Notices;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            FormSet.Letter1 = Form1Box.Text;
            FormSet.Letter2 = Form2Box.Text;
            FormSet.Letter3 = Form3Box.Text;
            FormSet.Regulations = RegsBox.Text;
            FormSet.Notices = NoticesBox.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
