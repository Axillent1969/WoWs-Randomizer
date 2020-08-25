using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.objects.ship;
using WoWs_Randomizer.utils;

namespace WoWs_Randomizer.forms
{
    public partial class CompareTool : Form
    {
        private CompareShip FirstChild = null;

        public CompareTool()
        {
            InitializeComponent();
            StatusText("Ready.");
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            using (ShipSelector select = new ShipSelector())
            {
                select.ShowDialog();
                if ( select.DialogResult == DialogResult.OK )
                {
                    string selection = select.SelectedShipName;
                    Ship findShip = Program.AllShips.Find(x => x.Name == selection);
                    AddShipToCompare(findShip);
                }
            }
        }

        private void AddShipToCompare(Ship findShip,ShipBuild build = null)
        {
            CompareShip childForm = new CompareShip();
            if (this.MdiChildren.Length == 0)
            {
                childForm.IsFirstChild = true;
                FirstChild = childForm;
            }

            childForm.MdiParent = this;
            string selection = findShip.Name;

            TableLayoutPanel tl = childForm.Controls.Find("ShipMetricsTable", true).FirstOrDefault() as TableLayoutPanel;
            MetricsExctractor Extractor = new MetricsExctractor(findShip);
            MetricsDrawer Drawer = new MetricsDrawer(tl);
            MetricsTableComposer.DrawTable(Extractor, Drawer);

            if ( build != null )
            {
                selection += "**PB**";
                BuildManagerHandler bmHandler = new BuildManagerHandler(tl, Extractor.GetMetrics());
                bmHandler.PerformAnimation(false);
                bmHandler.KeepBackgroundTransparent(true);
                bmHandler.ApplyAll(build.Flags);
                bmHandler.ApplyAll(build.Skills);
                bmHandler.ApplyAll(build.Upgrades);
                
                if ( build.GameVersion == null || build.GameVersion.Equals("") || build.GameVersion.Equals("0.9.4") )
                {
                    Settings settings = Commons.GetSettings();
                    if (settings.GameVersion.StartsWith("0.9.5") || settings.GameVersion.StartsWith("0.9.6"))
                    {
                        MessageBox.Show("This build was created before patch 0.9.5 and thus might not reflect correct values due to changes in Legendary Modules. Please resave this build in the Build Manager to make values correct.", "Build obsolete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            childForm.Text = selection;

            childForm.StartPosition = FormStartPosition.Manual;
            int positionX = (this.MdiChildren.Length-1) * 252;
            Point point = new Point(positionX, 0);
            childForm.Location = point;

            if (childForm.IsFirstChild == false)
            {
                MetricsCompare.DoCompare(childForm.Controls.Find("ShipMetricsTable", true).FirstOrDefault() as TableLayoutPanel, FirstChild.Controls.Find("ShipMetricsTable", true).FirstOrDefault() as TableLayoutPanel);
            }
            childForm.Show();
            toolStripStatusLabel.Text = "Added '" + selection + "' to compare.";
            statusStrip.Refresh();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            Settings settings = Commons.GetSettings();

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Randomizer Ship Build (*.bld)|*.bld";
            openFile.DefaultExt = "bld";
            openFile.InitialDirectory = settings.SaveLocation;

            string fileName = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileName = openFile.FileName;
            }
            else
            {
                return;
            }

            ShipBuild build = BinarySerialize.ReadFromBinaryFile<ShipBuild>(fileName);
            Ship findShip = Program.AllShips.Find(x => x.ID == build.ID);
            AddShipToCompare(findShip,build);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll_Click(sender, e);
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            foreach (CompareShip childForm in MdiChildren)
            {
                childForm.IsFirstChild = false;
                childForm.Close();
            }
            StatusText("Cleared all ships in comparison.");
        }

        private void StatusText(string text)
        {
            toolStripStatusLabel.Text = text;
            statusStrip.Refresh();
        }
    }
}
