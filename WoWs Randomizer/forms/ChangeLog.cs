using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWs_Randomizer.forms
{
    public partial class ChangeLog : Form
    {
        public List<string> log = new List<string>();

        public ChangeLog()
        {
            InitializeComponent();
        }

        private void ChangeLog_Load(object sender, EventArgs e)
        {
            string msg = "";
            foreach(string logentry in log)
            {
                msg += "- " + logentry + "\n\n";
            }

            logText.Text = msg;
        }
    }
}
