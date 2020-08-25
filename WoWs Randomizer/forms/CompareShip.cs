using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWs_Randomizer.forms
{
    public partial class CompareShip : Form
    {
        public bool IsFirstChild = false;

        public CompareShip()
        {
            InitializeComponent();
        }

        private void CompareShip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (IsFirstChild == true )
                {
                    MessageBox.Show("You can't delete the first ship in the comparison: If You need to start over - press the \"Delete All\"-button in the toolbar", "Unable to delete first item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                    this.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
    }
}
