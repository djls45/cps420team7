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
    public partial class ConfigForm : Form
    {
        public Configuration Config;

        public ConfigForm()
        {
            InitializeComponent();
        }
        
        public ConfigForm(Configuration config)
        {
            InitializeComponent();
            Config = config;
        }
    }
}
