using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.objects.modules;
using WoWs_Randomizer.objects.ship;
using WoWs_Randomizer.objects.skills;
using WoWs_Randomizer.objects.upgrades;
using WoWs_Randomizer.utils;

namespace WoWs_Randomizer.forms
{
    public partial class BuildManager : Form
    {
        private ShipMetrics Metrics = null;
        List<Skill> AllSkills = new List<Skill>();
        Ship selectedShip = null;

        public BuildManager()
        {
            InitializeComponent();
            //listUpgrades();
            //listShips();
            LoadCommanderSkills();
            LoadFlags();
        }

        private void listShips()
        {
            foreach(Ship ship in Program.AllShips)
            {
                //if ( ship.Tier == 10 )
                //{
                    Console.WriteLine(ship.ID + " - " + ship.Name + " (" + ship.Country + ") : " + ship.ShipType);
                //}
            }
        }

        private void listUpgrades()
        {
            foreach(Consumable upgrade in Program.Upgrades)
            {
                Console.WriteLine(upgrade.ID + " " + upgrade.Name + " : " + upgrade.Description);
                foreach(KeyValuePair<string,ConsumableProfile> profile in upgrade.Profile)
                {
                    Console.WriteLine(profile.Value.Description);
                }
            }
        }
        private void LoadFlags()
        {
            foreach(Consumable flag in Program.Flags)
            {
                //Console.WriteLine(flag.ID + " " + flag.Name + ", " + flag.Description + ", " + flag.Credits + ", " + flag.Gold);
                foreach(Control picCtr in panelFlags.Controls)
                {
                    if ( picCtr is PictureBox box)
                    {
                        if ( flag.ID == 4287459248)
                        {
                            //Console.WriteLine(box.AccessibleName.ToString() + " : " + flag.ID.ToString());
                        }
                        if ( box.AccessibleName != null && box.AccessibleName.ToString().Equals(flag.ID.ToString()))
                        {
                            ToolTip ttip = new ToolTip
                            {
                                AutoPopDelay = 8000,
                                ToolTipTitle = flag.Name
                            };
                            string text = "";
                            if (box.Tag != null && !box.Tag.Equals(""))
                            {
                                string tagText = box.Tag.ToString();
                                tagText = tagText.Replace("#", "\n");
                                text = tagText;
                            }
                            if ( !text.Equals(""))
                            {
                                text += "\n";
                            }

                            text += flag.Description;

                            if (flag.Profile.Count > 0)
                            {
                                text += "\n" + "--------------------------------------------------";
                            }
                            foreach (KeyValuePair<string, ConsumableProfile> perk in flag.Profile)
                            {
                                text += "\n" + perk.Value.Description;
                            }

/*                            if ( flag.ID == 42874592480)
                            {
                                string tagText = box.Tag.ToString();
                                tagText = tagText.Replace("#", "\n");
                                text = tagText + "\n";
                                text += flag.Description;
                                text += "\n" + "--------------------------------------------------";
                                foreach (KeyValuePair<string,ConsumableProfile> p in flag.Profile)
                                {
                                    Console.WriteLine(p.Value.Description);
                                    text += "\n" + p.Value.Description;
                                }
                            } else
                            {


                            }
*/
                            if (text.Equals("")) { text = flag.Name; }
                            ttip.SetToolTip(box, text);
                            break;
                        }
                    }
                }
            }
        }
        private void LoadCommanderSkills()
        {
            AllSkills = Program.CommanderSkills;
            foreach (Skill skill in AllSkills)
            {
                foreach (Control picCtrl in panelCaptainSkills.Controls)
                {
                    if (picCtrl is PictureBox box)
                    {
                        if (box.AccessibleName != null && box.AccessibleName.Equals(skill.Name))
                        {
                            box.Load(skill.ImageUrl);
                            ToolTip ttip = new ToolTip
                            {
                                AutoPopDelay = 8000,
                                ToolTipTitle = skill.Name
                            };
                            string text = "";
                            if (box.Tag != null && !box.Tag.Equals(""))
                            {
                                string tagText = box.Tag.ToString();
                                tagText = tagText.Replace("#", "\n");
                                text = tagText;
                            }
                            if (skill.Perks.Count > 0)
                            {
                                text += "\n" + "--------------------------------------------------";
                            }
                            foreach (Perk perk in skill.Perks)
                            {
                                text += "\n" + perk.Description;
                            }
                            if (text.Equals("")) { text = skill.Name; }
                            ttip.SetToolTip(box, text);
                            break;
                        }
                    }
                }
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            if ( box.AccessibleDescription == null || box.AccessibleDescription.Equals("") ) 
            {
                box.BorderStyle = BorderStyle.None;
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, box.ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoShipSelect();
        }
        private void ClearSelections()
        {
            upgradeSlot1.Controls.Clear();
            upgradeSlot2.Controls.Clear();
            upgradeSlot2.Visible = false;
            upgradeSlot2.Enabled = false;
            upgradeSlot3.Controls.Clear();
            upgradeSlot3.Visible = false;
            upgradeSlot3.Enabled = false;
            upgradeSlot4.Controls.Clear();
            upgradeSlot4.Visible = false;
            upgradeSlot4.Enabled = false;
            upgradeSlot5.Controls.Clear();
            upgradeSlot5.Visible = false;
            upgradeSlot5.Enabled = false;
            upgradeSlot6.Controls.Clear();
            upgradeSlot6.Visible = false;
            upgradeSlot6.Enabled = false;
            ShipMetricsTable.Controls.Clear();

            foreach(Control ctrl in panelCaptainSkills.Controls)
            {
                if ( ctrl is PictureBox box)
                {
                    box.BorderStyle = BorderStyle.None;
                    box.AccessibleDescription = "";
                    box.Refresh();
                }
            }
            totalSkillPoints.Text = "0";
            panelCaptainSkills.Enabled = false;

            foreach(Control ctrl in panelFlags.Controls)
            {
                if ( ctrl is PictureBox box)
                {
                    box.BorderStyle = BorderStyle.None;
                    box.AccessibleDescription = "";
                    box.Refresh();
                }
            }
            combatFlagsCount.Text = "0";
            panelFlags.Enabled = false;

            picShip.Image = null;
            selectedShip = null;
            Metrics = null;
            this.Text = "Build Manager";
        }
        public void SelectShip(Ship RandomizedShip)
        {
            ClearSelections();
            TableLayoutPanel tl = this.Controls.Find("ShipMetricsTable", true).FirstOrDefault() as TableLayoutPanel;
            MetricsExctractor Extractor = new MetricsExctractor(RandomizedShip);
            Metrics = Extractor.GetMetrics();
            MetricsDrawer Drawer = new MetricsDrawer(tl);
            MetricsTableComposer.DrawTable(Extractor, Drawer);
            picShip.Load(RandomizedShip.Images.Small);
            this.Text = "Build Manager: " + RandomizedShip.Name;
            panelCaptainSkills.Enabled = true;
            panelFlags.Enabled = true;
            upgradeSlot1.Enabled = true;

            if (RandomizedShip.Tier >= 3)
            {
                upgradeSlot2.Enabled = true;
                upgradeSlot2.Visible = true;
            }
            if (RandomizedShip.Tier >=5)
            {
                upgradeSlot3.Enabled = true;
                upgradeSlot3.Visible = true;
            }
            if ( RandomizedShip.Tier >= 6)
            {
                upgradeSlot4.Enabled = true;
                upgradeSlot4.Visible = true;
            }
            if ( RandomizedShip.Tier >= 8)
            {
                upgradeSlot5.Enabled = true;
                upgradeSlot5.Visible = true;
            }
            if ( RandomizedShip.Tier >= 9)
            {
                upgradeSlot6.Enabled = true;
                upgradeSlot6.Visible = true;
            }

            selectedShip = RandomizedShip;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            if ( box.AccessibleDescription == null || box.AccessibleDescription.Equals(""))
            {
                try 
                {
                    if ( box.Parent.Name.Equals("panelFlags"))
                    {
                        int count = int.Parse(combatFlagsCount.Text);
                        if ( box.AccessibleRole == AccessibleRole.Alert)
                        {
                            count++;
                            if ( count > 8 )
                            {
                                throw new Exception("You can only select 8 combat flags");
                            }
                            combatFlagsCount.Text = count.ToString();
                        }
                    } else
                    {
                        AddSkillPoints(box.AccessibleName); 
                    }
                    box.AccessibleDescription = "X";
                    BuildManagerHandler bmHandler = new BuildManagerHandler(ShipMetricsTable, Metrics);
                    bmHandler.ApplyValue(box.AccessibleName);
                    
                } 
                catch(Exception ex) 
                { 
                    MessageBox.Show(ex.Message, "Error allocating skillpoints/flags", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                    box.AccessibleDescription = ""; 
                }
                
            } else
            {
                if ( box.Parent.Name.Equals("panelFlags"))
                {
                    if ( box.AccessibleRole == AccessibleRole.Alert)
                    {
                        int count = int.Parse(combatFlagsCount.Text);
                        count--;
                        combatFlagsCount.Text = count.ToString();
                    }
                } else
                {
                    RemoveSkillPoints(box.AccessibleName);
                }
                box.AccessibleDescription = "";
                BuildManagerHandler bmHandler = new BuildManagerHandler(ShipMetricsTable, Metrics);
                bmHandler.RemoveValue(box.AccessibleName);
            }
            box.Refresh();
        }

        private void RemoveSkillPoints(string skillname)
        {
            Skill skill = AllSkills.Find(x => x.Name == skillname);
            if (skill != null)
            {
                int tier = skill.Tier;
                int currentPoints = int.Parse(totalSkillPoints.Text);
                currentPoints -= tier;

                totalSkillPoints.Text = currentPoints.ToString();
            }
        }

        private void AddSkillPoints(string skillname)
        {
            Skill skill = AllSkills.Find(x => x.Name == skillname);
            if ( skill != null )
            {
                int tier = skill.Tier;
                int currentPoints = int.Parse(totalSkillPoints.Text);
                currentPoints += tier;
                if ( currentPoints > 19 )
                {
                    throw new Exception("Unable to allocate more than 19 skillpoints!");
                }
                totalSkillPoints.Text = currentPoints.ToString();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ShipBuild build = new ShipBuild();
            build.ID = selectedShip.ID;
            build.Name = selectedShip.Name;

            List<string> skills = new List<string>();
            foreach (Control ctrl in panelCaptainSkills.Controls)
            {
                if (ctrl is PictureBox box)
                {
                    if (box.AccessibleDescription != null && !box.AccessibleDescription.ToString().Equals(""))
                    {
                        skills.Add(box.AccessibleName.ToString());
                    }
                }
            }
            build.Skills = skills;

            List<string> Flags = new List<string>();
            foreach (Control ctrl in panelFlags.Controls)
            {
                if (ctrl is PictureBox box)
                {
                    if (box.AccessibleDescription != null && !box.AccessibleDescription.ToString().Equals(""))
                    {
                        Flags.Add(box.AccessibleName.ToString());
                    }
                }
            }
            build.Flags = Flags;

            List<long> Upgrades = new List<long>();
            if (upgradeSlot1.Controls.Count > 0)
            {
                PictureBox box = (PictureBox)upgradeSlot1.Controls[0];
                if (!box.Tag.ToString().Equals(""))
                {
                    Upgrades.Add(long.Parse(box.Tag.ToString()));
                }
            }
            if (upgradeSlot2.Controls.Count > 0)
            {
                PictureBox box = (PictureBox)upgradeSlot2.Controls[0];
                if (!box.Tag.ToString().Equals(""))
                {
                    Upgrades.Add(long.Parse(box.Tag.ToString()));
                }
            }
            if (upgradeSlot3.Controls.Count > 0)
            {
                PictureBox box = (PictureBox)upgradeSlot3.Controls[0];
                if (!box.Tag.ToString().Equals(""))
                {
                    Upgrades.Add(long.Parse(box.Tag.ToString()));
                }
            }
            if (upgradeSlot4.Controls.Count > 0)
            {
                PictureBox box = (PictureBox)upgradeSlot4.Controls[0];
                if (!box.Tag.ToString().Equals(""))
                {
                    Upgrades.Add(long.Parse(box.Tag.ToString()));
                }
            }
            if (upgradeSlot5.Controls.Count > 0)
            {
                PictureBox box = (PictureBox)upgradeSlot5.Controls[0];
                if (!box.Tag.ToString().Equals(""))
                {
                    Upgrades.Add(long.Parse(box.Tag.ToString()));
                }
            }
            if (upgradeSlot6.Controls.Count > 0)
            {
                PictureBox box = (PictureBox)upgradeSlot6.Controls[0];
                if (!box.Tag.ToString().Equals(""))
                {
                    Upgrades.Add(long.Parse(box.Tag.ToString()));
                }
            }

            build.Upgrades = Upgrades;
            build.Modified = DateTime.Now;

            Settings settings = Commons.GetSettings();
            build.GameVersion = settings.GameVersion;

            string def = settings.SaveLocation;
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = def;
            saveDlg.DefaultExt = "bld";
            saveDlg.FileName = selectedShip.Name + ".bld";
            saveDlg.Filter = "Randomizer Ship Build (*.bld)|*.bld";
            if ( saveDlg.ShowDialog() == DialogResult.OK)
            {
                string file = saveDlg.FileName;
                if ( !file.EndsWith(".bld"))
                {
                    file += ".bld";
                }
                BinarySerialize.WriteToBinaryFile(file, build);
            }
        }

        public void LoadBuild(ShipBuild build)
        {
            Ship findShip = Program.AllShips.Find(x => x.ID == build.ID);
            SelectShip(findShip);

            foreach (string flag in build.Flags)
            {
                foreach (Control ctrl in panelFlags.Controls)
                {
                    if (ctrl is PictureBox box)
                    {
                        if (box.AccessibleName != null && box.AccessibleName.ToString().Equals(flag))
                        {
                            int count = int.Parse(combatFlagsCount.Text);
                            if (box.AccessibleRole == AccessibleRole.Alert)
                            {
                                count++;
                                combatFlagsCount.Text = count.ToString();
                            }
                            box.AccessibleDescription = "X";
                            box.Refresh();
                            BuildManagerHandler bmHandler = new BuildManagerHandler(ShipMetricsTable, Metrics);
                            bmHandler.PerformAnimation(false);
                            bmHandler.ApplyValue(box.AccessibleName);
                        }
                    }
                }
            }

            foreach (string skill in build.Skills)
            {
                foreach (Control ctrl in panelCaptainSkills.Controls)
                {
                    if (ctrl is PictureBox box)
                    {
                        if (box.AccessibleName != null && box.AccessibleName.ToString().Equals(skill))
                        {
                            AddSkillPoints(skill);
                            box.AccessibleDescription = "X";
                            BuildManagerHandler bmHandler = new BuildManagerHandler(ShipMetricsTable, Metrics);
                            bmHandler.PerformAnimation(false);
                            bmHandler.ApplyValue(box.AccessibleName);
                            box.Refresh();
                        }
                    }
                }
            }

            foreach (long upgradeId in build.Upgrades)
            {
                Consumable consumable = Program.Upgrades.Find(x => x.ID == upgradeId);

                PictureBox box = new PictureBox();
                box.Name = "Upgrade";
                box.AccessibleName = consumable.Name;
                box.Tag = consumable.ID;
                box.Load(consumable.ImageUrl);
                box.SizeMode = PictureBoxSizeMode.AutoSize;
                box.Location = new System.Drawing.Point(20, 15);
                ToolTip ttip = new ToolTip();
                ttip.SetToolTip(box, consumable.Name);
                
                if (consumable.Credits == 125000)
                {
                    upgradeSlot1.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot1, consumable.Name);
                }
                else if (consumable.Credits == 250000)
                {
                    upgradeSlot2.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot2, consumable.Name);
                }
                else if (consumable.Credits == 500000)
                {
                    upgradeSlot3.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot3, consumable.Name);
                }
                else if (consumable.Credits == 1000000)
                {
                    upgradeSlot4.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot4, consumable.Name);
                }
                else if (consumable.Credits == 2000000)
                {
                    upgradeSlot5.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot5, consumable.Name);
                }
                else if (consumable.Credits == 3000000)
                {
                    upgradeSlot6.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot6, consumable.Name);
                } else
                {
                    List<long> corrections = new List<long>();
                    UpgradeCorrections CorrectionsList = new UpgradeCorrections(selectedShip);
                    corrections = CorrectionsList.GetList();

                    Dictionary<int, List<long>> SlotCorrections = new Dictionary<int, List<long>>();
                    SlotCorrections = CorrectionsList.GetSlotCorrections();
                    foreach (long id in corrections)
                    {
                        for(int slot = 1; slot <= 6; slot++)
                        {
                            if ( SlotCorrections.ContainsKey(slot))
                            {
                                List<long> upgr = SlotCorrections[slot];
                                if (upgr.Contains(upgradeId))
                                {
                                    if ( slot == 1 ) 
                                    {
                                        ClearUpgradePanel(upgradeSlot1);
                                        upgradeSlot1.Controls.Add(box); 
                                    }
                                    if ( slot == 2 ) 
                                    {
                                        ClearUpgradePanel(upgradeSlot2);
                                        upgradeSlot2.Controls.Add(box); 
                                    }
                                    if ( slot == 3 ) 
                                    {
                                        ClearUpgradePanel(upgradeSlot3);
                                        upgradeSlot3.Controls.Add(box); 
                                    }
                                    if ( slot == 4 ) 
                                    {
                                        ClearUpgradePanel(upgradeSlot4);
                                        upgradeSlot4.Controls.Add(box); 
                                    }
                                    if ( slot == 5 ) 
                                    {
                                        ClearUpgradePanel(upgradeSlot5);
                                        upgradeSlot5.Controls.Add(box); 
                                    }
                                    if ( slot == 6 ) 
                                    { 
                                        ClearUpgradePanel(upgradeSlot6);
                                        upgradeSlot6.Controls.Add(box); 
                                    }
                                }
                            }
                        }
                    }
                }

                applyUpgradeValues(consumable.ID.ToString(), false);
            }
        }

        private void ClearUpgradePanel(Panel UpgradePanel)
        {
            if ( UpgradePanel.Controls.Count > 0 )
            {
                ToolTip ttip = new ToolTip();
                ttip.SetToolTip(UpgradePanel, ""); 

                PictureBox existing = (PictureBox)UpgradePanel.Controls[0];
                string existingId = existing.AccessibleName;
                removeUpgradeValues(existingId);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = Commons.GetSettings();

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Randomizer Ship Build (*.bld)|*.bld";
            openFile.DefaultExt = "bld";
            openFile.InitialDirectory = settings.SaveLocation;

            string fileName = "";
            if ( openFile.ShowDialog() == DialogResult.OK)
            {
                fileName = openFile.FileName;
            } else
            {
                return;
            }

            ShipBuild build = BinarySerialize.ReadFromBinaryFile<ShipBuild>(fileName);
            LoadBuild(build);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ClearSelections();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DoShipSelect();
        }

        private void DoShipSelect()
        {
            using (ShipSelector select = new ShipSelector())
            {
                select.Text = "Select ship";
                select.ShowDialog();
                if (select.DialogResult == DialogResult.OK)
                {
                    string selection = select.SelectedShipName;
                    Ship findShip = Program.AllShips.Find(x => x.Name == selection);
                    SelectShip(findShip);
                }
            }
        }

        private void upgradeSlot1_Click(object sender, EventArgs e)
        {
            if ( selectedShip == null ) { return;  }

            Panel panel = (Panel)sender;
            int slot = int.Parse(panel.Tag.ToString());
            long creditValue = 125000;
            if ( slot == 2 )
            {
                creditValue = 250000;
            } else if ( slot == 3)
            {
                creditValue = 500000;
            } else if ( slot == 4)
            {
                creditValue = 1000000;
            } else if ( slot == 5)
            {
                creditValue = 2000000;
            } else if ( slot == 6)
            {
                creditValue = 3000000;
            }
            upgradeSelect.Tag = panel.Tag;
            upgradeSelect.Controls.Clear();
            List<Consumable> UpgradeSlotSelected = new List<Consumable>();
            selectedShip.Upgrades.Append<long>(4221751216);

            foreach (long id in selectedShip.Upgrades)
            {
                Consumable Upgrade = Program.Upgrades.Find(x => x.ID == id);
                if (Upgrade.Credits.Equals(creditValue))
                {
                    UpgradeSlotSelected.Add(Upgrade);
                }
            }

            List<long> corrections = new List<long>();
            UpgradeCorrections CorrectionsList = new UpgradeCorrections(selectedShip);
            corrections = CorrectionsList.GetList();

            Dictionary<int, List<long>> SlotCorrections = new Dictionary<int, List<long>>();
            SlotCorrections = CorrectionsList.GetSlotCorrections();

            foreach(long id in corrections)
            {
                Consumable Upgrade = Program.Upgrades.Find(x => x.ID == id);

                if (Upgrade.Credits.Equals(creditValue))
                {
                    UpgradeSlotSelected.Add(Upgrade);

                } else if (SlotCorrections.ContainsKey(slot) )
                {
                    List<long> upgr = SlotCorrections[slot];
                    if ( upgr.Contains(Upgrade.ID) )
                    {
                        UpgradeSlotSelected.Add(Upgrade);
                    }
                }
            }
            TableLayoutPanel uPanel = new TableLayoutPanel();
            uPanel.AutoSize = true;
            uPanel.Controls.Clear();
            uPanel.RowStyles.Clear();
            uPanel.RowCount = 0;

            uPanel.ColumnCount = 1;
            uPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));

            int count = 0;
            foreach (Consumable upgrade in UpgradeSlotSelected)
            {
                string perks = "";
                foreach(KeyValuePair<string,ConsumableProfile> prof in upgrade.Profile)
                {
                    ConsumableProfile profile = prof.Value;
                    perks += profile.Description + "\n";
                }

                int posY = (count * 65) + 10;
                PictureBox box = new PictureBox();
                
                box.Load(upgrade.ImageUrl);
                box.Tag = upgrade.ID;
                box.AccessibleName = upgrade.Name.Replace("\n"," ");
                box.SizeMode = PictureBoxSizeMode.AutoSize;
                box.Location = new System.Drawing.Point(10, posY);
                box.Click += Box_Click;
                box.Margin = new Padding(5);
                box.Cursor = Cursors.Hand;

                ToolTip ttip = new ToolTip();
                ttip.SetToolTip(box, "Select this upgrade for the slot");

                uPanel.RowCount += 1;
                uPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));

                uPanel.Controls.Add(box, 0, uPanel.RowCount - 1);

                Label text = new Label();
                Label head = new Label();
                head.Text = upgrade.Name.Replace("\n"," ");
                head.Font = new Font(this.Font, FontStyle.Bold);
                head.AutoSize = true;

                if ( perks.Equals(""))
                {
                    text.Text = upgrade.Description;
                } else
                {
                    text.Text = upgrade.Description + "\n" + perks;
                }
                if ( upgrade.ID == 4286762928)
                {
                    text.Text = "Decreases reload time of torpedo tubes.\nTorpedo tubes reload time: -15%\nRisk of torpedo tubes becoming incapacitated: +50%";
                }
                text.AutoSize = true;
                text.TextAlign = ContentAlignment.MiddleLeft;

                text.Margin = new Padding(2);

                text.Height = box.Height + 10;
                uPanel.RowCount += 1;
                uPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
                uPanel.Controls.Add(head, 0, uPanel.RowCount - 1);
                uPanel.RowCount += 1;
                uPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
                uPanel.Controls.Add(text, 0, uPanel.RowCount - 1);

                count++;
            }
            uPanel.Refresh();
            upgradeSelect.Controls.Add(uPanel);
            upgradeSelect.AutoSize = true;
            upgradeSelect.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            upgradeSelect.Padding = new Padding(8);
            upgradeSelect.Refresh();

            System.Drawing.Point p = Cursor.Position;
            p.X = 25;
            p.Y = p.Y + 12;
            int test = p.Y + 12 + upgradeSelect.Height + 26;

            if ( test >= this.Height )
            {
                p.Y -= (upgradeSelect.Height + 120);
            }
            if ( p.Y < 20 )
            {
                p.Y = 20;
            }
            upgradeSelect.Location = p;
            upgradeSelect.BringToFront();
            upgradeSelect.Refresh();
            upgradeSelect.Visible = true;
        }

        private void Box_Click(object sender, EventArgs e)
        {
            PictureBox selectedBox = (PictureBox)sender;
            PictureBox box2 = new PictureBox();
            box2.Name = "Upgrade";
            box2.AccessibleName = selectedBox.AccessibleName;
            box2.Image = selectedBox.Image;
            box2.Tag = selectedBox.Tag;
            box2.SizeMode = PictureBoxSizeMode.AutoSize;
            box2.Location = new System.Drawing.Point(20, 15);

            ToolTip ttip = new ToolTip();
            ttip.SetToolTip(box2, selectedBox.AccessibleName);

            string selectedSlot = selectedBox.Parent.Parent.Tag.ToString();

            Panel slot = this.Controls.Find("upgradeSlot" + selectedSlot, true).FirstOrDefault() as Panel;
            if ( slot != null )
            {
                PictureBox oldPicture = slot.Controls.Find("Upgrade", true).FirstOrDefault() as PictureBox;
                if (oldPicture != null )
                {
                    removeUpgradeValues(oldPicture.Tag.ToString());
                }
            }
            slot.Controls.Clear();
            slot.Controls.Add(box2);

            ttip.SetToolTip(slot, selectedBox.AccessibleName);

            upgradeSelect.Visible = false;

            applyUpgradeValues(box2.Tag.ToString());
        }

        private void applyUpgradeValues(string upgradeId, bool animate = true)
        {
            BuildManagerHandler bmHandler = new BuildManagerHandler(ShipMetricsTable, Metrics);
            bmHandler.PerformAnimation(animate);
            bmHandler.ApplyValue(upgradeId);

        }

        private void removeUpgradeValues(string upgradeId)
        {
            BuildManagerHandler bmHandler = new BuildManagerHandler(ShipMetricsTable, Metrics);
            bmHandler.PerformAnimation(false);
            bmHandler.RemoveValue(upgradeId);
        }
    }
}
