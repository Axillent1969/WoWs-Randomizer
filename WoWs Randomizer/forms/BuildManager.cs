using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.objects.consumables;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.ship;
using WoWs_Randomizer.utils.skills;

namespace WoWs_Randomizer.forms
{
    public partial class BuildManager : Form
    {
        private ShipMetrics Metrics = null;
        List<Skill> AllSkills = new List<Skill>();
        Ship selectedShip = null;
        private BuildManagerHandler bmHandler = null;
        Dictionary<string, Image> skillsPictures = new Dictionary<string, Image>();
        private LogHandler LOG = Program.LOG;

        public BuildManager()
        {
            LOG.Debug("BuildManager: START");
            InitializeComponent();
            LoadFlags();
            LoadSkillPictures();
        }

        private void LoadFlags()
        {
            LOG.Debug("LoadFlags()");
            foreach(Consumable flag in Program.Flags)
            {
                foreach(Control picCtr in panelFlags.Controls)
                {
                    if ( picCtr is PictureBox box)
                    {
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

                            if (text.Equals("")) { text = flag.Name; }
                            ttip.SetToolTip(box, text);
                            break;
                        }
                    }
                }
            }
        }

        private void LoadSkills(string commanderSkillset)
        {
            LOG.Debug("LoadSkills(" + commanderSkillset + ")");
            try
            {
                List<Skill> skills = Program.CommanderSkills[commanderSkillset];
                skills.Sort();
                RenderPictureBoxes(skills, commanderSkillset);
            } catch(Exception e)
            {
                LOG.Error("Unable to process skills: " + commanderSkillset, e);
                MessageBox.Show("Unable to process skills. Try to restart the program and try again");
            }
        }

        private void RenderPictureBoxes(List<Skill> skills, string commanderSkillset)
        {
            LOG.Debug("RenderPictureBoxes(" + skills.Count + ", " + commanderSkillset + ")");
            foreach (Skill s in skills)
            {
                PictureBox pb = (PictureBox)panelCaptainSkills.Controls["pic" + s.SortBy.ToString()];
                if (s.ImageUrl == null || s.ImageUrl.Equals(""))
                {
                    if ( skillsPictures.ContainsKey(commanderSkillset + s.SortBy.ToString()))
                    {
                        pb.Image = skillsPictures[commanderSkillset + s.SortBy.ToString()];
                    } else
                    {
                        pb.Image = null;
                    }
                }
                else
                {
                    pb.Load(s.ImageUrl);
                }
                pb.AccessibleName = s.Name;

                ToolTip ttip = new ToolTip
                {
                    AutomaticDelay = 500,
                    AutoPopDelay = 9000,
                    ToolTipTitle = s.Name
                };
                string tagText = s.Description + "\n" + s.Effect + "\n" + s.Notes;
                ttip.SetToolTip(pb, tagText);
            }
        }

        private void LoadCommanderSkills()
        {

            //LoadBBSkills();

/*            AllSkills = Program.CommanderSkills;
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
            }*/
        }

        private void LoadSkillPictures()
        {
            LOG.Debug("Loading image sets");
            skillsPictures.Add("bb11", Properties.BBSkills.gun_feeder);
            skillsPictures.Add("bb12", Properties.BBSkills.pyrotechnician);
            skillsPictures.Add("bb13", Properties.BBSkills.consumables_specialist);
            skillsPictures.Add("bb21", Properties.BBSkills.grease_the_gears);
            skillsPictures.Add("bb22", Properties.BBSkills.inertia_fuse_for_he_shells);
            skillsPictures.Add("bb23", Properties.BBSkills.consumables_enhancements);
            skillsPictures.Add("bb31", Properties.BBSkills.super_heavy_ap_shells);
            skillsPictures.Add("bb32", Properties.BBSkills.long_range_secondary_battery_shells);
            skillsPictures.Add("bb33", Properties.BBSkills.adrenaline_rush);
            skillsPictures.Add("bb41", Properties.BBSkills.dead_eye);
            skillsPictures.Add("bb42", Properties.BBSkills.improved_scondary_battery_aiming);
            skillsPictures.Add("bb43", Properties.BBSkills.close_quarters_combat);
            skillsPictures.Add("bb14", Properties.BBSkills.emergency_repair_specialist);
            skillsPictures.Add("bb15", Properties.BBSkills.incoming_fire_alert);
            skillsPictures.Add("bb16", Properties.BBSkills.preventive_maintnance);
            skillsPictures.Add("bb24", Properties.BBSkills.vigilance);
            skillsPictures.Add("bb25", Properties.BBSkills.priority_target);
            skillsPictures.Add("bb26", Properties.BBSkills.aa_gunner);
            skillsPictures.Add("bb34", Properties.BBSkills.basics_of_survivability);
            skillsPictures.Add("bb35", Properties.BBSkills.enhanced_anti_torpedo_protection);
            skillsPictures.Add("bb36", Properties.BBSkills.expert_aa_marksman);
            skillsPictures.Add("bb44", Properties.BBSkills.emergency_repair_expert);
            skillsPictures.Add("bb45", Properties.BBSkills.concealment_expert);
            skillsPictures.Add("bb46", Properties.BBSkills.fire_prevention_expert);

            skillsPictures.Add("dd11", Properties.DDSkills.grease_the_gears);
            skillsPictures.Add("dd12", Properties.DDSkills.liquidator);
            skillsPictures.Add("dd13", Properties.DDSkills.consumables_specialist);
            skillsPictures.Add("dd14", Properties.DDSkills.gun_feeder);
            skillsPictures.Add("dd21", Properties.DDSkills.pyrotechnician);
            skillsPictures.Add("dd22", Properties.DDSkills.swift_fish);
            skillsPictures.Add("dd23", Properties.DDSkills.consumables_enhancements);
            skillsPictures.Add("dd24", Properties.DDSkills.extra_heavy_ap_shells);
            skillsPictures.Add("dd31", Properties.DDSkills.main_battery_and_aa_specialist);
            skillsPictures.Add("dd32", Properties.DDSkills.fill_the_tubes);
            skillsPictures.Add("dd33", Properties.DDSkills.adrenaline_rush);
            skillsPictures.Add("dd34", Properties.DDSkills.inertia_fuse_for_he_shells);
            skillsPictures.Add("dd41", Properties.DDSkills.main_battery_and_aa_expert);
            skillsPictures.Add("dd42", Properties.DDSkills.swift_in_silence);
            skillsPictures.Add("dd43", Properties.DDSkills.radio_location);
            skillsPictures.Add("dd44", Properties.DDSkills.fearless_brawler);
            skillsPictures.Add("dd15", Properties.DDSkills.incoming_fire_alert);
            skillsPictures.Add("dd16", Properties.DDSkills.preventive_maintenance);
            skillsPictures.Add("dd25", Properties.DDSkills.priority_target);
            skillsPictures.Add("dd26", Properties.DDSkills.last_stand);
            skillsPictures.Add("dd35", Properties.DDSkills.superintendent);
            skillsPictures.Add("dd36", Properties.DDSkills.survivability_expert);
            skillsPictures.Add("dd45", Properties.DDSkills.concealment_expert);
            skillsPictures.Add("dd46", Properties.DDSkills.dazzle);

            skillsPictures.Add("ca11", Properties.DDSkills.grease_the_gears);
            skillsPictures.Add("ca12", Properties.DDSkills.swift_fish);
            skillsPictures.Add("ca13", Properties.DDSkills.consumables_specialist);
            skillsPictures.Add("ca14", Properties.DDSkills.gun_feeder);
            skillsPictures.Add("ca15", Properties.DDSkills.incoming_fire_alert);
            skillsPictures.Add("ca16", Properties.DDSkills.last_stand);

            skillsPictures.Add("ca21", Properties.DDSkills.pyrotechnician);
            skillsPictures.Add("ca22", Properties.DDSkills.fill_the_tubes);
            skillsPictures.Add("ca23", Properties.DDSkills.consumables_enhancements);
            skillsPictures.Add("ca24", Properties.CASkills.eye_in_the_sky);
            skillsPictures.Add("ca25", Properties.DDSkills.priority_target);
            skillsPictures.Add("ca26", Properties.BBSkills.expert_aa_marksman);

            skillsPictures.Add("ca31", Properties.CASkills.heavy_he_and_sap_shells);
            skillsPictures.Add("ca32", Properties.CASkills.enhanced_torpedo_explosive_charge);
            skillsPictures.Add("ca33", Properties.DDSkills.adrenaline_rush);
            skillsPictures.Add("ca34", Properties.CASkills.heavy_ap_shells);
            skillsPictures.Add("ca35", Properties.DDSkills.superintendent);
            skillsPictures.Add("ca36", Properties.DDSkills.survivability_expert);

            skillsPictures.Add("ca41", Properties.CASkills.top_grade_gunner);
            skillsPictures.Add("ca42", Properties.CASkills.outnumbered);
            skillsPictures.Add("ca43", Properties.DDSkills.radio_location);
            skillsPictures.Add("ca44", Properties.DDSkills.inertia_fuse_for_he_shells);
            skillsPictures.Add("ca45", Properties.DDSkills.concealment_expert);
            skillsPictures.Add("ca46", Properties.CASkills.aa_gunner);

            skillsPictures.Add("cv11", Properties.CVSkills.last_grasp);
            skillsPictures.Add("cv12", Properties.CVSkills.improved_engine_boost);
            skillsPictures.Add("cv13", Properties.CVSkills.engine_techie);
            skillsPictures.Add("cv14", Properties.CVSkills.air_supremacy);
            skillsPictures.Add("cv15", Properties.CVSkills.direction_center_for_fighters);
            skillsPictures.Add("cv16", Properties.CVSkills.search_and_destroy);

            skillsPictures.Add("cv21", Properties.CVSkills.torpedo_bomber);
            skillsPictures.Add("cv22", Properties.DDSkills.swift_fish);
            skillsPictures.Add("cv23", Properties.CVSkills.improved_engines);
            skillsPictures.Add("cv24", Properties.CVSkills.repair_specialist);
            skillsPictures.Add("cv25", Properties.CVSkills.secondary_armament_expert);
            skillsPictures.Add("cv26", Properties.CVSkills.patrol_group_leader);

            skillsPictures.Add("cv31", Properties.CVSkills.sight_stabilization);
            skillsPictures.Add("cv32", Properties.CVSkills.enhanced_armor_piercing_ammunition);
            skillsPictures.Add("cv33", Properties.DDSkills.pyrotechnician);
            skillsPictures.Add("cv34", Properties.CVSkills.aircraft_armor);
            skillsPictures.Add("cv35", Properties.CVSkills.survivability_expert_cv);
            skillsPictures.Add("cv36", Properties.CVSkills.interceptor);

            skillsPictures.Add("cv41", Properties.CVSkills.bomber_flight_control);
            skillsPictures.Add("cv42", Properties.CVSkills.proximity_fuze);
            skillsPictures.Add("cv43", Properties.CVSkills.close_quarters_expert);
            skillsPictures.Add("cv44", Properties.CVSkills.enhanced_aircraft_armor);
            skillsPictures.Add("cv45", Properties.CVSkills.hidden_menace);
            skillsPictures.Add("cv46", Properties.CVSkills.enhanced_reactions);

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
            LOG.Debug("button2_Click");
            DoShipSelect();
        }

        private void ClearSelections(bool keepSelectedShip = false)
        {
            LOG.Debug("ClearSelections(" + keepSelectedShip + ")");
            bmHandler = null;
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
                    box.Image = null;
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

            Metrics = null;
            if ( keepSelectedShip == false)
            {
                picShip.Image = null;
                selectedShip = null;
                this.Text = "Build Manager";
            } else
            {
                SelectShip(selectedShip);
            }
        }

        public void SelectShip(Ship RandomizedShip)
        {
            LOG.Debug("SelectShip(" + RandomizedShip.Name + ")");
            ClearSelections();
            selectedShip = RandomizedShip;

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

            string type = RandomizedShip.ShipType.ToLower();
            LoadSkills(AbbreviateShipType(type));
            
            bmHandler = new BuildManagerHandler(ShipMetricsTable, Metrics);
        }

        private string AbbreviateShipType(string longShipType)
        {
            if (longShipType.Equals("battleship"))
            {
                return "bb";
            }
            else if (longShipType.Equals("cruiser"))
            {
                return "ca";
            }
            else if (longShipType.Equals("destroyer"))
            {
                return "dd";
            }
            else if (longShipType.Equals("aircarrier"))
            {
                return "cv";
            }
            return "";
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            LOG.Debug("pictureBox_Click");
            bool isCommanderSkill = false;
            PictureBox box = (PictureBox)sender;
            if ( box.AccessibleDescription == null || box.AccessibleDescription.Equals(""))
            {
                try 
                {
                    if ( box.Parent.Name.Equals("panelFlags"))
                    {
                        LOG.Debug("panelFlags");
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
                        LOG.Debug("CommanderSkill = true");
                        isCommanderSkill = true;
                        AddSkillPoints(box.AccessibleName); 
                    }
                    box.AccessibleDescription = "X";
                    if ( isCommanderSkill )
                    {
                        Skill currentSkill = FindSkillByAccessibleName(box.AccessibleName);
                        if ( currentSkill != null )
                        {
                            foreach(Perk perk in currentSkill.Perks)
                            {
                                bmHandler.ApplyValue(perk.ID, perk.Value);
                            }
                        }
                    } else
                    {
                        bmHandler.ApplyValue(box.AccessibleName);
                    }
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
                    isCommanderSkill = true;
                    RemoveSkillPoints(box.AccessibleName);
                }
                box.AccessibleDescription = "";
                if ( isCommanderSkill )
                {
                    Skill currentSkill = FindSkillByAccessibleName(box.AccessibleName);
                    if (currentSkill != null)
                    {
                        foreach (Perk perk in currentSkill.Perks)
                        {
                            bmHandler.RemoveValue(perk.ID, perk.Value);
                        }
                    }
                } else
                {
                    bmHandler.RemoveValue(box.AccessibleName);
                }
            }
            box.Refresh();
        }

        private Skill FindSkillByAccessibleName(string accessibleName)
        {
            LOG.Debug("FindSkillByAccessibleName(" + accessibleName + ")");
            string type = selectedShip.ShipType.ToLower();
            string commanderSkillset = AbbreviateShipType(type);
            List<Skill> skills = Program.CommanderSkills[commanderSkillset];
            Skill currentSkill = skills.Find(s => s.Name.Equals(accessibleName));
            LOG.Debug("Return: " + currentSkill.Name);
            return currentSkill;
        }

        private void RemoveSkillPoints(string skillname)
        {
            LOG.Debug("RemoveSkillPoints(" + skillname + ")");
            Skill skill = FindSkillByAccessibleName(skillname);
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
            LOG.Debug("AddSkillPoints(" + skillname + ")");
            Skill skill = FindSkillByAccessibleName(skillname);
            if ( skill != null )
            {
                int tier = skill.Tier;
                int currentPoints = int.Parse(totalSkillPoints.Text);
                currentPoints += tier;
                if ( currentPoints > 21 )
                {
                    throw new Exception("Unable to allocate more than 21 skillpoints!");
                }
                totalSkillPoints.Text = currentPoints.ToString();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOG.Debug("exitTooStripMenuItem_Click()");
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOG.Debug("SaveBuild()");
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
            build.GameVersion = Program.Settings.GameVersion;

            string def = Program.Settings.SaveLocation;
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
            LOG.Debug("LoadBuild(" + build.ID + ")");
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
                            bmHandler.PerformAnimation(false);

                            Skill currentSkill = FindSkillByAccessibleName(box.AccessibleName);
                            if (currentSkill != null)
                            {
                                foreach (Perk perk in currentSkill.Perks)
                                {
                                    bmHandler.ApplyValue(perk.ID, perk.Value);
                                }
                            }

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
                box.Click += upgradeSlot1_Click;

                ToolTip ttip = new ToolTip();
                ttip.SetToolTip(box, consumable.Name);
                
                if (consumable.GetSlotNumber() == 1)
                {
                    upgradeSlot1.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot1, consumable.Name);
                }
                else if (consumable.GetSlotNumber() == 2)
                {
                    upgradeSlot2.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot2, consumable.Name);
                }
                else if (consumable.GetSlotNumber() == 3)
                {
                    upgradeSlot3.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot3, consumable.Name);
                }
                else if (consumable.GetSlotNumber() == 4)
                {
                    upgradeSlot4.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot4, consumable.Name);
                }
                else if (consumable.GetSlotNumber() == 5)
                {
                    upgradeSlot5.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot5, consumable.Name);
                }
                else if (consumable.GetSlotNumber() == 6)
                {
                    upgradeSlot6.Controls.Add(box);
                    ttip.SetToolTip(upgradeSlot6, consumable.Name);
                }
                applyUpgradeValues(consumable.ID.ToString(), false);
            }
            bmHandler.PerformAnimation(true);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Randomizer Ship Build (*.bld)|*.bld";
            openFile.DefaultExt = "bld";
            openFile.InitialDirectory = Program.Settings.SaveLocation;

            if ( openFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFile.FileName;
                ShipBuild build = BinarySerialize.ReadFromBinaryFile<ShipBuild>(fileName);
                LoadBuild(build);
            } else
            {
                return;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            LOG.Debug("toolStripButton4_Click()");
            if ( MessageBox.Show("This will remove the selected ship and all selected skills, upgrades and flags. Unsaved changes will be lost.\nDo You want to continue?","Clear selection",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
            {
                ClearSelections();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LOG.Debug("toolStripButton1_Click()");
            DoShipSelect();
        }

        private void DoShipSelect()
        {
            LOG.Debug("DoShipSelect()");
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
            LOG.Debug("upgradeSlot1_Click()");
            Panel panel = null;
            if ( sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;
                panel = (Panel)pb.Parent;
            } else
            {
                panel = (Panel)sender;
            }
            int slot = int.Parse(panel.Tag.ToString());

            UpgradeSelector selectorDlg = new UpgradeSelector();
            selectorDlg.SelectedSlot = slot;
            selectorDlg.SelectedShip = selectedShip;

            selectorDlg.ShowDialog();
            if (selectorDlg.DialogResult == DialogResult.OK)
            {
                Box_Click(selectorDlg.SelectedUpgrade, null, slot);
            }
            selectorDlg.Dispose();
        }

        private void Box_Click(object sender, EventArgs e, int selectedSlot = 1)
        {
            LOG.Debug("Box_Click()");
            PictureBox selectedBox = (PictureBox)sender;
            PictureBox box2 = new PictureBox();
            box2.Name = "Upgrade";
            box2.AccessibleName = selectedBox.AccessibleName;
            box2.Image = selectedBox.Image;
            box2.Tag = selectedBox.Tag;
            box2.SizeMode = PictureBoxSizeMode.AutoSize;
            box2.Location = new System.Drawing.Point(20, 15);
            box2.Click += upgradeSlot1_Click;

            ToolTip ttip = new ToolTip();
            ttip.SetToolTip(box2, selectedBox.AccessibleName);

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

            applyUpgradeValues(box2.Tag.ToString());
        }

        private void applyUpgradeValues(string upgradeId, bool animate = true)
        {
            LOG.Debug("applyUpgradeValues(" + upgradeId + ", " + animate + ")");
            bmHandler.PerformAnimation(animate);
            bmHandler.ApplyValue(upgradeId);
        }

        private void removeUpgradeValues(string upgradeId)
        {
            LOG.Debug("removeUpgradeValues(" + upgradeId + ")");
            bmHandler.PerformAnimation(false);
            bmHandler.RemoveValue(upgradeId);
            bmHandler.PerformAnimation(true);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LOG.Debug("toolStripButton3_Click()");
            if ( selectedShip != null )
            {
                ;
                if (MessageBox.Show("This will unselect every skill, upgrade and flag selected in the build but keep the current ship as selected ship. Unsaved changes will be lost.\nDo You want to continue?", "Clear selections", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ClearSelections(true);
                }
            }
        }
    }
}
