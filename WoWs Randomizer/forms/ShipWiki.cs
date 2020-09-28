using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoWs_Randomizer.objects.module;
using WoWs_Randomizer.objects.modules;
using WoWs_Randomizer.objects.ship;
using WoWs_Randomizer.objects.ship.profile;
using WoWs_Randomizer.utils.metrics;

namespace WoWs_Randomizer.forms
{
    public partial class ShipWiki : Form
    {
        private Ship selectedShip = null;
        private ToolTip ttip = new ToolTip();

        public ShipWiki()
        {
            InitializeComponent();
        }

        private void ShipWiki_Load(object sender, EventArgs e)
        {
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

        private void SelectShip(Ship selectedShip)
        {
            this.selectedShip = selectedShip;
            InfoPanel.TabPages[0].Text = "General: " + selectedShip.Name;
            FillInfoPanel();
        }

        private void FillInfoPanel()
        {
            FillGeneralTab();
            FillHullTab();
            FillEngineTab();
            FillMainArmamentsTab();
            FillSecondaryArmamentsTab();
            FillTorpedoTab();
        }

        private void FillTorpedoTab()
        {
            ClearTab(Torpedo.Controls, "Torpedo");
            int c = 0;
            foreach(long torpId in selectedShip.Modules.Torpedoes)
            {
                ModuleData module = Program.AllModules[torpId.ToString()];
                TorpedoExtractor extractor = new TorpedoExtractor(module);
                foreach (Control ctr in Torpedo.Controls)
                {
                    if (ctr.Name.Equals("torp" + c.ToString()))
                    {
                        TableLayoutPanel panel = getTable(ctr);
                        PictureBox picture = getPicture(ctr);
                        Label nameLabel = getLabel(ctr);

                        nameLabel.Text = module.Name;
                        if ( module.ImageUrl != null )
                        {
                            picture.Load(module.ImageUrl);
                        }
                        panel.Controls.Clear();
                        panel.Controls.Add(createHeadlineLabel("ID"), 0, 0);
                        panel.Controls.Add(createLabel(module.ID.ToString()), 0, 1);

                        panel.Controls.Add(createHeadlineLabel("Reload time"), 1, 0);
                        panel.Controls.Add(createLabel(extractor.ReloadTime.ToString() + " sec."), 1, 1);

                        panel.Controls.Add(createHeadlineLabel("Damage"), 2, 0);
                        panel.Controls.Add(createLabel(extractor.Damage.ToString()),2, 1);

                        panel.Controls.Add(createHeadlineLabel("Speed"), 3, 0);
                        panel.Controls.Add(createLabel(extractor.TravelSpeed.ToString()), 3, 1);

                        panel.Controls.Add(createHeadlineLabel("Range"), 4, 0);
                        panel.Controls.Add(createLabel(extractor.Distance.ToString()), 4, 1);

                        panel.Controls.Add(createHeadlineLabel("Credit cost"), 5, 0);
                        panel.Controls.Add(createLabel(module.PriceCredits.ToString()), 5, 1);

                        ctr.Visible = true;
                    }
                }
                c++;
            }

        }
        private void FillSecondaryArmamentsTab()
        {
            ClearTab(SecondaryArmament.Controls, "secondary");

            Secondaries sec = selectedShip.Profile.Secondaries;
            if ( sec == null ) { return; }

            foreach(KeyValuePair<string,SecondariesData> kvPair in sec.Slots)
            {
                SecondariesData secData = kvPair.Value;
                foreach(Control ctr in SecondaryArmament.Controls)
                {
                    if ( ctr.Name.Equals("secondary" + kvPair.Key))
                    {
                        TableLayoutPanel panel = getTable(ctr);
                        if ( panel != null )
                        {
                            panel.Controls.Clear();
                            panel.Controls.Add(createHeadlineLabel("Name"), 0, 0);
                            panel.Controls.Add(createLabel(secData.Name), 0, 1);

                            panel.Controls.Add(createHeadlineLabel("Range"), 1, 0);
                            panel.Controls.Add(createLabel(sec.Distance.ToString() + " km"), 1, 1);

                            panel.Controls.Add(createHeadlineLabel("Firechance"), 2, 0);
                            panel.Controls.Add(createLabel(secData.FireChance.ToString() + " %"), 2, 1);

                            panel.Controls.Add(createHeadlineLabel("Reload time"), 3, 0);
                            panel.Controls.Add(createLabel(secData.ReloadTime().ToString()), 3, 1);
                        }
                        ctr.Visible = true;
                    }
                }
            }
        }

        private void ClearTab(Control.ControlCollection controlCollection, string tabName)
        {
            foreach (Control ctr in controlCollection)
            {
                if (ctr.Name.StartsWith(tabName))
                {
                    foreach (Control pctrl in ctr.Controls)
                    {
                        if (pctrl is TableLayoutPanel)
                        {
                            TableLayoutPanel p = (TableLayoutPanel)pctrl;
                            p.Controls.Clear();
                        }
                        else if (pctrl is PictureBox)
                        {
                            PictureBox p = (PictureBox)pctrl;
                            p.Image = null;
                        }
                        else if (pctrl is Label)
                        {
                            Label lbl = (Label)pctrl;
                            lbl.Text = "";
                        }
                    }
                    ctr.Visible = false;
                }
            }
        }

        private void FillMainArmamentsTab()
        {
            ClearTab(MainArmament.Controls, "main");
            int c = 0;
            foreach(long artilleryId in selectedShip.Modules.Artillery)
            {
                ModuleData module = Program.AllModules[artilleryId.ToString()];
                foreach(Control ctr in MainArmament.Controls)
                {
                    if ( ctr.Name.Equals("main"+c.ToString()))
                    {
                        ctr.Visible = true;
                        LoadMainArmamentsControl(module, ctr);
                    }
                }
                c++;
            }
        }

        private void LoadMainArmamentsControl(ModuleData module, Control control)
        {
            TableLayoutPanel panel = getTable(control);
            PictureBox picture = getPicture(control);
            Label nameLabel = getLabel(control);
            ArtilleryExtractor extractor = new ArtilleryExtractor(module, selectedShip);

            if (module.ImageUrl.Equals("") && picture != null)
            {
                picture.Image = null;
            }
            else
            {
                if (picture != null)
                {
                    picture.Load(module.ImageUrl);
                }
            }
            nameLabel.Text = module.Name;

            panel.Controls.Add(createHeadlineLabel("ID"),0, 0);
            panel.Controls.Add(createLabel(module.ID.ToString()), 0, 1);

            panel.Controls.Add(createHeadlineLabel("Caliber"), 1, 0);
            panel.Controls.Add(createLabel(extractor.GunCaliber().ToString()), 1, 1);

            double reloadTime = Math.Round(60 / extractor.FireRate(),1);

            panel.Controls.Add(createHeadlineLabel("Reload time"), 2, 0);
            panel.Controls.Add(createLabel(reloadTime.ToString()), 2, 1);

            double speed = 180 / extractor.RotationTime();
            double rotation = Math.Round(speed, 1);

            panel.Controls.Add(createHeadlineLabel("Rotation"), 3, 0);
            panel.Controls.Add(createLabel(rotation.ToString() + " deg/sec"), 3, 1);

            panel.Controls.Add(createHeadlineLabel("AP"), 4, 0);
            panel.Controls.Add(createLabel(extractor.APDamage().ToString()), 4, 1);

            panel.Controls.Add(createHeadlineLabel("HE"), 5, 0);
            panel.Controls.Add(createLabel(extractor.HEDamage().ToString()), 5, 1);

            panel.Controls.Add(createHeadlineLabel("Credits"), 6, 0);
            panel.Controls.Add(createLabel(extractor.CreditCost().ToString()), 6, 1);

            panel.Controls.Add(createHeadlineLabel("Dispersion (m)"), 7, 0);
            panel.Controls.Add(createLabel(extractor.Dispersion().ToString()), 7, 1);
        }

        private void FillEngineTab()
        {
            ClearTab(Engine.Controls, "enginePanel");
            int c = 0;
            foreach (long engineId in selectedShip.Modules.Engine)
            {
                ModuleData module = Program.AllModules[engineId.ToString()];

                foreach (Control ctr in Engine.Controls)
                {
                    if (ctr.Name.Equals("enginePanel" + c.ToString()))
                    {
                        ctr.Visible = true;
                        LoadControl(module, ctr);
                    }
                }
                c++;
            }
        }

        private void FillHullTab()
        {
            ClearTab(Hull.Controls, "hullPanel");
            int c = 0;
            foreach(long hullId in selectedShip.Modules.Hull)
            {
                ModuleData module = Program.AllModules[hullId.ToString()];

                foreach(Control ctr in Hull.Controls)
                {
                    if ( ctr.Name.Equals("hullPanel"+c.ToString()))
                    {
                        ctr.Visible = true;
                        LoadControl(module, ctr);
                    }
                }
                c++;
            }
        }

        private void FillGeneralTab()
        {
            ShipName.Text = selectedShip.Name;
            LoadFlag(selectedShip.Country);
            FlagImage.Tag = selectedShip.Country;
            ShipImage.Load(selectedShip.Images.Small);
            DescriptionBox.Text = selectedShip.Description;
            lblPremium.Text = "Premium: " + TranslateTrueFalse(selectedShip.Premium); ;
            lblDemo.Text = "Demo: " + TranslateTrueFalse(selectedShip.DemoProfile);
            lblID.Text = "ID: " + selectedShip.ID.ToString() + " (" + selectedShip.ShipId + ")";
            lblCostCredits.Text = "Cost: " + selectedShip.PriceCredits.ToString();
            lblCostGold.Text = "Cost (gold): " + selectedShip.PriceGold.ToString();
            lblSlots.Text = "Number of slots: " + selectedShip.NumberOfSlots.ToString();
            lblSpecial.Text = "Special: " + TranslateTrueFalse(selectedShip.Special);
            lblTier.Text = "Tier: " + selectedShip.Tier.ToString();
            lblShipType.Text = "Shiptype: " + selectedShip.ShipType;

            lblTurningRadius.Text = "Turning Radius: " + selectedShip.Profile.Mobility.TurningRadius.ToString() + " m";
            lblTurningSpeed.Text = "Ruddershift: " + selectedShip.Profile.Mobility.RudderTime.ToString() + " sec";

            lblAirDet.Text = selectedShip.Profile.Concealment.AirDetection.ToString() + " km";
            lblSurfaceDet.Text = selectedShip.Profile.Concealment.SurfaceDetection.ToString() + " km";
            
            addConsumablesImages(selectedShip);
        }

        private void addConsumablesImages(Ship selectedShip)
        {
            for(int i = 1; i <= 10; i++)
            {
                PictureBox pb = (PictureBox)General.Controls["consumable" + i];
                pb.Visible = false;
            }

            int upgradeCount = 0;
            UpgradeCorrections corrections = new UpgradeCorrections(selectedShip);
            if ( corrections.canEquipRepairParty())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY010_RegenCrew;
                ttip.SetToolTip(pb,"Repair party");
                pb.Refresh();
                pb.Visible = true;
            }
            if ( corrections.canEquipSpecializedHeal())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY010_SpecializedHeal_Premium;
                ttip.SetToolTip(pb, "Specialized Repair party");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipDefAAMod1())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY011_AirDefenseDispPremium;
                ttip.SetToolTip(pb, "Defensive AA");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipEngineBoostMod1())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY015_SpeedBoosterPremium;
                ttip.SetToolTip(pb, "Engine Boost");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipHydroMod1())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY016_SonarSearchPremium;
                ttip.SetToolTip(pb, "Hydroacoustic Search");
                pb.Refresh();
                pb.Visible = true;
            }

            if (corrections.canEquipSmokeGeneratorMod1())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY006_SmokeGenerator;
                ttip.SetToolTip(pb, "Smoke Generator");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipCrawlingSmoke())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY006_SmokeGeneratorCrawler;
                ttip.SetToolTip(pb, "Crawling Smoke Generator");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipExhaustSmoke())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY006_SmokeGeneratorOil;
                ttip.SetToolTip(pb, "Exhaust Smoke Generator");
                pb.Refresh();
                pb.Visible = true;
            }

            if (corrections.canEquipCatapultFighter())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY012_FighterPremium;
                ttip.SetToolTip(pb, "Catapult fighter");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipSpottingAircraftMod1())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY005_Spotter;
                ttip.SetToolTip(pb, "Spotting aircraft");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipSRM1())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY020_RadarPremium;
                ttip.SetToolTip(pb, "Surveillance Radar");
                pb.Refresh();
                pb.Visible = true;
            }

            if ( corrections.canEquipMainBatteryReloadBooster())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY022_ArtilleryBoosterPremium;
                ttip.SetToolTip(pb, "Main Battery Reload Booster");
                pb.Refresh();
                pb.Visible = true;
            }
            if ( corrections.canEquipTorpReloadBooster())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY018_TorpedoReloaderPremium;
                ttip.SetToolTip(pb, "Torpedo Reload Booster");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipCAPFighters())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY012_FighterPremium;
                ttip.SetToolTip(pb, "CAP Fighters");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipEngineCooling())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY015_SpeedBoosterPremium;
                ttip.SetToolTip(pb, "Engine Cooling");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipPatrolFighters())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY012_FighterPremium;
                ttip.SetToolTip(pb, "Engine Cooling");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipAircraftRepair())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY036_AircraftRepair;
                ttip.SetToolTip(pb, "Aircraft Repair");
                pb.Refresh();
                pb.Visible = true;
            }
            if (corrections.canEquipMaxDepth())
            {
                upgradeCount++;
                PictureBox pb = (PictureBox)General.Controls["consumable" + upgradeCount];
                pb.Image = Properties.Resources.Consumable_PCY043_Max_Depth;
                ttip.SetToolTip(pb, "Maximum Depth");
                pb.Refresh();
                pb.Visible = true;
            }
        }

        private void LoadFlag(string Country)
        {

            Dictionary<string, string> Flags = new Dictionary<string, string>
            {
                { "japan", "https://wiki.gcdn.co/images/5/5b/Wows_flag_Japan.png" },
                { "usa", "https://wiki.gcdn.co/images/f/f2/Wows_flag_USA.png" },
                { "ussr", "https://wiki.gcdn.co/images/0/04/Wows_flag_Russian_Empire_and_USSR.png" },
                { "germany", "https://wiki.gcdn.co/images/6/6b/Wows_flag_Germany.png" },
                { "uk", "https://wiki.gcdn.co/images/3/34/Wows_flag_UK.png" },
                { "commonwealth", "https://wiki.gcdn.co/images/9/9a/Wows_flag_Commonwealth.png" },
                { "france", "https://wiki.gcdn.co/images/7/71/Wows_flag_France.png" },
                { "italy", "https://wiki.gcdn.co/images/d/d1/Wows_flag_Italy.png" },
                { "pan_asia", "https://wiki.gcdn.co/images/3/33/Wows_flag_Pan_Asia.png" },
                { "pan_america", "https://wiki.gcdn.co/images/9/9e/Wows_flag_Pan_America.png" },
                { "europe", "https://wiki.gcdn.co/images/5/52/Wows_flag_Europe.png" }
            };

            string url = Flags[Country.ToLower()];
            FlagImage.Load(url);
        }

        private string TranslateTrueFalse(bool state)
        {
            if ( state )
            {
                return "Yes";
            }
            return "No";
        }

        private void LoadControl(ModuleData module, Control control)
        {
            TableLayoutPanel panel = getTable(control);
            PictureBox picture = getPicture(control);
            if (module.ImageUrl.Equals("") && picture != null)
            {
                picture.Image = null;
            }
            else
            {
                if ( picture != null)
                {
                    picture.Load(module.ImageUrl);
                }
            }

            panel.Controls.Add(createHeadlineLabel("Name"), 0, 0);
            panel.Controls.Add(createLabel(module.Name), 0, 1);

            panel.Controls.Add(createHeadlineLabel("ID"), 1, 0);
            panel.Controls.Add(createLabel(module.ID.ToString()), 1, 1);

            string headline = "";
            string data = "";

            if ( module.Type.Equals("Hull"))
            {
                headline = "HP";
                if (module.HullHealth != 0)
                {
                    data = module.HullHealth.ToString();
                }
                else
                {
                    data = module.Profile["hull"]["health"].ToString();
                }
            } else if ( module.Type.Equals("Engine"))
            {
                headline = "Max speed (knots)";
                if (module.EngineSpeed != 0)
                {
                    data = module.EngineSpeed.ToString();
                }
                else
                {
                    data = (string)module.Profile["engine"]["max_speed"];
                }
            }

            panel.Controls.Add(createHeadlineLabel(headline), 2, 0);
            panel.Controls.Add(createLabel(data), 2, 1);

            panel.Controls.Add(createHeadlineLabel("Credit cost"), 3, 0);
            panel.Controls.Add(createLabel(module.PriceCredits.ToString()), 3, 1);
        }

        private TableLayoutPanel getTable(Control ctr)
        {
            foreach (Control pctrl in ctr.Controls)
            {
                if (pctrl is TableLayoutPanel)
                {
                    return (TableLayoutPanel)pctrl;
                }
            }
            return null;
        }

        private PictureBox getPicture(Control ctr)
        {
            foreach (Control pctrl in ctr.Controls)
            {
                if (pctrl is PictureBox)
                {
                    return (PictureBox)pctrl;
                }
            }
            return null;
        }

        private Label getLabel(Control ctr)
        {
            foreach(Control pctrl in ctr.Controls)
            {
                if ( pctrl is Label)
                {
                    return (Label)pctrl;
                }
            }
            return null;
        }

        private Label createHeadlineLabel(string text)
        {
            Label headline = new Label();
            headline.Text = text;
            headline.Font = new Font(headline.Font, FontStyle.Bold);
            return headline;
        }

        private Label createLabel(string text)
        {
            Label lblText = new Label();
            lblText.Text = text;
            return lblText;
        }

        private void ShipImage_Click(object sender, EventArgs e)
        {
            string HREF = @"https://wiki.wargaming.net/en/Ship:";
            string SelectedShip = ShipName.Text.ToString();

            if (SelectedShip.Equals(""))
            {
                return;
            }
            else
            {
                SelectedShip = SelectedShip.Replace(' ', '_');
                System.Diagnostics.Process.Start(HREF + SelectedShip);
            }
        }
    }
}
