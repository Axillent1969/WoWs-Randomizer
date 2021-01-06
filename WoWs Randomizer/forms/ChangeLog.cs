using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WoWs_Randomizer.objects.version;

namespace WoWs_Randomizer.forms
{
    public partial class ChangeLog : Form
    {
        public List<ProgramVersionLog> LogEntries = new List<ProgramVersionLog>();

        public ChangeLog()
        {
            InitializeComponent();
        }

        private void ChangeLog_Load(object sender, EventArgs e)
        {

            string msg = "";

            foreach(ProgramVersionLog logEntry in LogEntries)
            {
                msg += logEntry.Version + " (" + logEntry.Date + "): \n";
                foreach(string note in logEntry.Log)
                {
                    msg += "- " + note + "\n\n";
                }
            }

            logText.Text = msg;

        }
    }
}
