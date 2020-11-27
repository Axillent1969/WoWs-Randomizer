using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WoWs_Randomizer.utils.ship;

namespace WoWs_Randomizer.forms
{
    public partial class ShipSelector : Form
    {
        public string SelectedShipName = "";
        public ShipSelector()
        {
            InitializeComponent();
        }

        private void ShipSelector_Load(object sender, EventArgs e)
        {
            List<string> selectionSource = new List<string>();
            foreach (Ship ship in Program.AllShips) {
                if ( !ship.Name.StartsWith("["))
                {
                    selectionSource.Add(ship.Name);
                }
            }
            selectionSource.Add(" --SELECT SHIP-- ");
            selectionSource.Sort();

            shipSelectionBox.DataSource = selectionSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selection = "";
            if ( shipSelectionBox.SelectedItem != null )
            {
                selection = shipSelectionBox.SelectedItem.ToString();
            } else
            {
                selection = shipSelectionBox.Text;
            }
            if ( selection.Equals(" --SELECT SHIP-- "))
            {
                return;
            }
            Ship findShip = Program.AllShips.Find(x => x.Name == selection);
            if ( findShip == null )
            {
                MessageBox.Show("Unable to find a ship with that name: " + selection, "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.SelectedShipName = shipSelectionBox.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
