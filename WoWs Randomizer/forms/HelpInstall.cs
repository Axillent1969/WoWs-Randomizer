using System;
using System.Windows.Forms;

namespace WoWs_Randomizer.forms
{
    public partial class HelpInstall : Form
    {
        public HelpInstall()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            string HREF = @"https://discord.gg/UfHhQ6d";
            System.Diagnostics.Process.Start(HREF);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
