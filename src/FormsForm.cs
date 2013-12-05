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
        }
    }
}
