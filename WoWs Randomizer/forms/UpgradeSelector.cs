using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WoWs_Randomizer.objects.consumables;
using WoWs_Randomizer.utils.modules;
using WoWs_Randomizer.utils.ship;

namespace WoWs_Randomizer.forms
{
    public partial class UpgradeSelector : Form
    {
        public long SelectedID = 0;
        public PictureBox SelectedUpgrade = null;
        public int SelectedSlot = 0;
        //public long CreditValue = 0;
        public Ship SelectedShip = null;

        public UpgradeSelector()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedID = getSelectedUpgradeId();
            SelectedUpgrade = getSelectedUpgrade();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private PictureBox getSelectedUpgrade()
        {
            PictureBox selected = null;
            foreach (Control ctrl in leftPanel.Controls)
            {
                foreach (PictureBox pb in ctrl.Controls.OfType<PictureBox>().ToList())
                {
                    if (pb.AccessibleDescription != null && pb.AccessibleDescription.Equals("X"))
                    {
                        selected = pb;
                        break;
                    }
                }
            }

            if (selected != null)
            {
                return selected;
            }
            return null;
        }
        private long getSelectedUpgradeId()
        {
            PictureBox selected = null;
            foreach (Control ctrl in leftPanel.Controls)
            {
                foreach(PictureBox pb in ctrl.Controls.OfType<PictureBox>().ToList())
                {
                    if ( pb.AccessibleDescription != null && pb.AccessibleDescription.Equals("X"))
                    {
                        selected = pb;
                        break;
                    }
                }
            }

            if ( selected != null )
            {
                return long.Parse(selected.Tag.ToString());
            }
            return 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PaintTable()
        {
            List<Consumable> Upgrades = PrepareUpgrades();
            if ( Upgrades.Count > 4)
            {
                TableLayoutPanel tlp1 = BuildPanel(Upgrades, 0, 4);
                TableLayoutPanel tlp2 = BuildPanel(Upgrades, 4, 99);
                leftPanel.Controls.Add(tlp1);
                rightPanel.Controls.Add(tlp2);
                leftPanel.Refresh();
                rightPanel.Show();
                rightPanel.Refresh();
            } else
            {
                TableLayoutPanel panel = BuildPanel(Upgrades,0);
                leftPanel.Controls.Add(panel);
                leftPanel.Refresh();
                rightPanel.Hide();
            }
            this.Refresh();
        }

        private TableLayoutPanel BuildPanel(List<Consumable> Upgrades, int Position = 0, int Max = 4)
        {
            TableLayoutPanel uPanel = new TableLayoutPanel();
            uPanel.AutoSize = true;
            uPanel.Controls.Clear();
            uPanel.RowStyles.Clear();
            uPanel.RowCount = 0;

            uPanel.ColumnCount = 1;
            uPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));

            int count = 0;
            for(int c = 0; c < Upgrades.Count;c++)
            {
                if ( Position != 0 && c <= Position-1 )
                {
                    continue;
                } else if ( count >= Max ) { break; }
                Consumable upgrade = Upgrades[c];

                int posY = (count * 65) + 10;
                PictureBox box = GeneratePictureBox(upgrade, posY);
                uPanel.RowCount += 1;
                uPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
                uPanel.Controls.Add(box, 0, uPanel.RowCount - 1);

                Label head = GenerateHeadline(upgrade.Name);
                uPanel.RowCount += 1;
                uPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
                uPanel.Controls.Add(head, 0, uPanel.RowCount - 1);

                string labelText;
                // Hardcoded correction of incorrect text of upgrade 4286762928
                if (upgrade.ID == 4286762928)
                {
                    labelText = "Decreases reload time of torpedo tubes.\nTorpedo tubes reload time: -15%\nRisk of torpedo tubes becoming incapacitated: +50%";
                } else
                {
                    string perks = ExtractPerks(upgrade);
                    labelText = upgrade.Description + perks;
                }
                Label text = GenerateTextLabel(labelText, box.Height);
                uPanel.RowCount += 1;
                uPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
                uPanel.Controls.Add(text, 0, uPanel.RowCount - 1);

                count++;
            }
            uPanel.Refresh();

            return uPanel;
        }

        private PictureBox GeneratePictureBox(Consumable upgrade, int posY)
        {
            PictureBox box = new PictureBox();

            box.Load(upgrade.ImageUrl);
            box.Tag = upgrade.ID;
            box.AccessibleName = upgrade.Name.Replace("\n", " ");
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.Location = new System.Drawing.Point(10, posY);
            box.Click += Box_Click;
            box.Paint += Box_Paint;
            box.Margin = new Padding(5);
            box.Cursor = Cursors.Hand;
            return box;
        }

        private Label GenerateHeadline(string LabelText)
        {
            Label head = new Label();
            head.Text = LabelText.Replace("\n", " ");
            head.Font = new Font(this.Font, FontStyle.Bold);
            head.AutoSize = true;
            return head;
        }

        private Label GenerateTextLabel(string LabelText, int Height)
        {
            Label text = new Label();

            text.Text = LabelText;
            text.AutoSize = true;
            text.TextAlign = ContentAlignment.MiddleLeft;

            text.Margin = new Padding(2);

            text.Height = Height + 10;
            return text;
        }

        private string ExtractPerks(Consumable upgrade)
        {
            string perks = "";
            foreach (KeyValuePair<string, ConsumableProfile> prof in upgrade.Profile)
            {
                ConsumableProfile profile = prof.Value;
                perks += "\n" + profile.Description;
            }
            return perks;
        }

        private void ClearAllSelections()
        {
            foreach(Control ctrl in leftPanel.Controls)
            {
                ClearPictureBoxBorder(ctrl.Controls.OfType<PictureBox>().ToList());

            }
            foreach (Control ctrl in rightPanel.Controls)
            {
                ClearPictureBoxBorder(ctrl.Controls.OfType<PictureBox>().ToList());
            }
            this.Update();
        }

        private void ClearPictureBoxBorder(List<PictureBox> pbList)
        {
            foreach(PictureBox pb in pbList)
            {
                pb.AccessibleDescription = "";
                pb.Refresh();
            }
        }

        private void Box_Click(object sender, EventArgs e)
        {
            ClearAllSelections();
            PictureBox box = (PictureBox)sender;
            box.AccessibleDescription = "X";
            box.Refresh();
            this.Update();
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            if (box.AccessibleDescription == null || box.AccessibleDescription.Equals(""))
            {
                box.BorderStyle = BorderStyle.None;
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, box.ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
            }
        }

        private List<Consumable> PrepareUpgrades()
        {
            List<Consumable> UpgradeSlotSelected = new List<Consumable>();

            SelectedShip.Upgrades.Append<long>(4221751216);

            foreach (long id in SelectedShip.Upgrades)
            {
                // Do not include obsolete upgrades; Main Battery Mod 1, Propulsion Mod 1 etc...
                Consumable Upgrade = Program.Upgrades.Find(x => x.ID == id);
                if (Upgrade.isObsolete() == false && Upgrade.GetSlotNumber() == SelectedSlot)
                {
                    UpgradeSlotSelected.Add(Upgrade);
                }
            }

            List<long> corrections = new List<long>();
            UpgradeCorrections CorrectionsList = new UpgradeCorrections(SelectedShip);
            corrections = CorrectionsList.GetList();

            foreach (long id in corrections)
            {
                Consumable Upgrade = Program.Upgrades.Find(x => x.ID == id);
                if (Upgrade.GetSlotNumber() == SelectedSlot)
                {
                    UpgradeSlotSelected.Add(Upgrade);
                }
            }

            return UpgradeSlotSelected;
        }

        private void UpgradeSelector_Shown(object sender, EventArgs e)
        {
            if ( this.SelectedSlot > 0 && this.SelectedShip != null )
            {
                PaintTable();
            }
        }
    }
}
