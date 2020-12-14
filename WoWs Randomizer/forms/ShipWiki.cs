using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WoWs_Randomizer.utils.module;
using WoWs_Randomizer.utils.ship;
using WoWs_Randomizer.utils.ship.profile;
using WoWs_Randomizer.utils.metrics;
using WoWs_Randomizer.objects.consumables;
using static WoWs_Randomizer.utils.ConsumableTypes;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.api;
using System.Linq;
using WoWs_Randomizer.utils.modules;

namespace WoWs_Randomizer.forms
{
    public partial class ShipWiki : Form
    {
        private Ship selectedShip = null;
        private ToolTip ttip = new ToolTip();
        public bool IsBuilderActive = false;

        private List<Consumable> UpgradeSlotSelected = new List<Consumable>();

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
            FillUpgradesTab();
            FillEngineTab();
            FillMainArmamentsTab();
            FillSecondaryArmamentsTab();
            FillGFCSTab();
            FillTorpedoTab();
            FillFlightControlTab();
            FillPlanesTab();
        }

        private int GetCheckedSlotNumber()
        {
            int selectedSlot = 0;
            if (rbSlot1.Checked) { selectedSlot = 1; }
            else if (rbSlot2.Checked) { selectedSlot = 2; }
            else if (rbSlot3.Checked) { selectedSlot = 3; }
            else if (rbSlot4.Checked) { selectedSlot = 4; }
            else if (rbSlot5.Checked) { selectedSlot = 5; }
            else if (rbSlot6.Checked) { selectedSlot = 6; }
            return selectedSlot;
        }

        private void FillUpgradesTab()
        {
            UpgradeSlotSelected.Clear();
            int selectedSlot = GetCheckedSlotNumber();

            UpgradeCorrections CorrectionsList = new UpgradeCorrections(selectedShip);

            selectedShip.Upgrades.Append(4221751216);

            foreach (long id in selectedShip.Upgrades)
            {
                // Do not include obsolete upgrades; Main Battery Mod 1, Propulsion Mod 1 etc...
                Consumable Upgrade = Program.Upgrades.Find(x => x.ID == id);
                if ( Upgrade.isObsolete() == false )
                {
                    UpgradeSlotSelected.Add(Upgrade);
                }
            }

            List<long> corrections = new List<long>();
            corrections = CorrectionsList.GetList();
            foreach (long id in corrections)
            {
                Consumable Upgrade = Program.Upgrades.Find(x => x.ID == id);

                UpgradeSlotSelected.Add(Upgrade);
            }

            UpgradeSlotSelected.Sort();
            UpdateUpgradePanels(selectedSlot);
        }

        private void UpdateUpgradePanels(int selectedSlot)
        {
            ClearUpgradePanels();
            int upgradeNumber = 0;
            foreach (Consumable Upgrade in UpgradeSlotSelected)
            {
                if (Upgrade != null && Upgrade.GetSlotNumber() == selectedSlot)
                {
                    AddUpgradePanel(Upgrade, upgradeNumber);
                    upgradeNumber++;
                }
            }
        }

        private void ClearUpgradePanels()
        {
            for(int i = 0; i <= 5;i++)
            {
                Panel pnl = (Panel)Upgrades.Controls["upgrade" + i];
                Label lblHead = (Label)pnl.Controls["lblHeadline" + i];
                Label lblDesc = (Label)pnl.Controls["lblDescription" + i];
                Label lblPerks = (Label)pnl.Controls["lblPerks" + i];
                Label lblCost = (Label)pnl.Controls["lblCostSlot" + i];

                lblCost.Text = "-";
                lblPerks.Text = "-";
                lblDesc.Text = "-";
                lblHead.Text = "-";
                pnl.Visible = false;
                pnl.Refresh();
            }
        }

        private void AddUpgradePanel(Consumable upgrade,int upgradeNo)
        {
            if (upgradeNo < 0 || upgradeNo > 5) { return; }

            Panel pnl = (Panel)Upgrades.Controls["upgrade" + upgradeNo];
            if (pnl != null)
            {
                Label lblHead = (Label)pnl.Controls["lblHeadline" + upgradeNo];
                Label lblDesc = (Label)pnl.Controls["lblDescription" + upgradeNo];
                Label lblPerks = (Label)pnl.Controls["lblPerks" + upgradeNo];
                Label lblCost = (Label)pnl.Controls["lblCostSlot" + upgradeNo];

                lblHead.Text = upgrade.Name.Replace("\n","");
                lblDesc.Text = upgrade.Description;

                string perks = "";
                foreach (KeyValuePair<string, ConsumableProfile> prof in upgrade.Profile)
                {
                    ConsumableProfile profile = prof.Value;
                    perks += profile.Description + "\n";
                }
                lblPerks.Text = perks;

                PictureBox pb = (PictureBox)pnl.Controls["picture" + upgradeNo];
                pb.Load(upgrade.ImageUrl);

                string txt = "Credits: " + upgrade.Credits;
                lblCost.Text = txt;

                pnl.Visible = true;
                pnl.Refresh();
            }
        }

        private void FillGFCSTab()
        {
            ClearTab(GFCS.Controls, "gfcs");
            int c = 0;
            foreach (long id in selectedShip.Modules.FireControl)
            {
                ModuleData module = Program.AllModules[id.ToString()];
                foreach(Control ctr in GFCS.Controls)
                {
                    if ( ctr.Name.Equals("gfcs"+c.ToString()))
                    {
                        TableLayoutPanel panel = getTable(ctr);
                        PictureBox picture = getPicture(ctr);
                        Label lblName = getLabel(ctr);

                        if ( module.ImageUrl != null )
                        {
                            picture.Load(module.ImageUrl);
                        }
                        lblName.Text = module.Name;

                        panel.Controls.Clear();
                        panel.Controls.Add(createHeadlineLabel("ID"), 0, 0);
                        panel.Controls.Add(createLabel(module.ID.ToString()), 0, 1);

                        panel.Controls.Add(createHeadlineLabel("Cost"), 1, 0);
                        panel.Controls.Add(createLabel(module.PriceCredits.ToString()), 1, 1);

                        panel.Controls.Add(createHeadlineLabel("Distance (km)"), 2, 0);
                        panel.Controls.Add(createLabel(module.FireDistance.ToString()), 2, 1);

                        ctr.Visible = true;
                    }
                }
                c++;
            }
        }

        private void FillPlanesTab()
        {
            const string CTRLNAME = "plane";
            ClearTab(Planes.Controls, "plane");
            int c = 0;
            foreach (long dbId in selectedShip.Modules.DiveBomber)
            {
                ModuleData module = Program.AllModules[dbId.ToString()];

                foreach (Control ctr in Planes.Controls)
                {
                    if (ctr.Name.Equals(CTRLNAME + c.ToString()))
                    {
                        TableLayoutPanel panel = getTable(ctr);
                        PictureBox picture = getPicture(ctr);
                        if (module.ImageUrl != null)
                        {
                            picture.Load(module.ImageUrl);
                        }
                        panel.Controls.Clear();
                        panel.Controls.Add(createHeadlineLabel("Name"), 0, 0);
                        panel.Controls.Add(createLabel(module.Name), 0, 1);

                        panel.Controls.Add(createHeadlineLabel("ID"), 1, 0);
                        panel.Controls.Add(createLabel(module.ID.ToString()), 1, 1);

                        panel.Controls.Add(createHeadlineLabel("Cost"), 2, 0);
                        panel.Controls.Add(createLabel(module.PriceCredits.ToString()), 2, 1);

                        string value = "";
                        if (module.DiveBomber != null)
                        {
                            value = module.DiveBomber.MaxDamage.ToString() + " / ";
                            value += module.DiveBomber.MaxHealth.ToString() + " HP / ";
                            value += module.DiveBomber.CruiseSpeed.ToString() + " knots";

                            panel.Controls.Add(createHeadlineLabel("Dive Bomber:"), 3, 0);
                            panel.Controls.Add(createLabel(value), 3, 1);
                        }
                        ctr.Visible = true;
                    }
                }
                c++;
            }

            foreach (long dbId in selectedShip.Modules.TorpedoBomber)
            {
                ModuleData module = Program.AllModules[dbId.ToString()];

                foreach (Control ctr in Planes.Controls)
                {
                    if (ctr.Name.Equals(CTRLNAME + c.ToString()))
                    {
                        TableLayoutPanel panel = getTable(ctr);
                        PictureBox picture = getPicture(ctr);
                        if (module.ImageUrl != null)
                        {
                            picture.Load(module.ImageUrl);
                        }
                        panel.Controls.Clear();
                        panel.Controls.Add(createHeadlineLabel("Name"), 0, 0);
                        panel.Controls.Add(createLabel(module.Name), 0, 1);

                        panel.Controls.Add(createHeadlineLabel("ID"), 1, 0);
                        panel.Controls.Add(createLabel(module.ID.ToString()), 1, 1);

                        panel.Controls.Add(createHeadlineLabel("Cost"), 2, 0);
                        panel.Controls.Add(createLabel(module.PriceCredits.ToString()), 2, 1);

                        string value = "";
                        if (module.TorpedoBomber != null)
                        {
                            value = module.TorpedoBomber.MaxDamage.ToString() + " (";
                            value += module.TorpedoBomber.TorpedoSpeed + " knots) / ";
                            value += module.TorpedoBomber.Health.ToString() + " HP / ";
                            value += module.TorpedoBomber.CruiseSpeed.ToString() + " knots";

                            panel.Controls.Add(createHeadlineLabel("Torpedo Bomber:"), 3, 0);
                            panel.Controls.Add(createLabel(value), 3, 1);
                        }

                        ctr.Visible = true;
                    }
                }
                c++;
            }

            foreach (long dbId in selectedShip.Modules.Fighter)
            {
                ModuleData module = Program.AllModules[dbId.ToString()];

                foreach (Control ctr in Planes.Controls)
                {
                    if (ctr.Name.Equals(CTRLNAME + c.ToString()))
                    {
                        TableLayoutPanel panel = getTable(ctr);
                        PictureBox picture = getPicture(ctr);
                        if (module.ImageUrl != null)
                        {
                            picture.Load(module.ImageUrl);
                        }
                        panel.Controls.Clear();
                        panel.Controls.Add(createHeadlineLabel("Name"), 0, 0);
                        panel.Controls.Add(createLabel(module.Name), 0, 1);

                        panel.Controls.Add(createHeadlineLabel("ID"), 1, 0);
                        panel.Controls.Add(createLabel(module.ID.ToString()), 1, 1);

                        panel.Controls.Add(createHeadlineLabel("Cost"), 2, 0);
                        panel.Controls.Add(createLabel(module.PriceCredits.ToString()), 2, 1);

                        string value = "";
                        if (module.Fighter != null)
                        {
                            value = module.Fighter.Health.ToString() + " HP / ";
                            value += module.Fighter.CruiseSpeed.ToString() + " knots";

                            panel.Controls.Add(createHeadlineLabel("Fighter:"), 3, 0);
                            panel.Controls.Add(createLabel(value), 3, 1);
                        }

                        ctr.Visible = true;
                    }
                }
                c++;
            }
        }

        private void FillFlightControlTab()
        {
            ClearTab(CV.Controls, "cv");
            int c = 1;
            foreach(long fcId in selectedShip.Modules.FlightControl)
            {
                ModuleData module = Program.AllModules[fcId.ToString()];
                
                foreach(Control ctr in CV.Controls)
                {
                    if ( ctr.Name.Equals("cvPanel" + c.ToString()))
                    {
                        TableLayoutPanel panel = getTable(ctr);
                        PictureBox picture = getPicture(ctr);
                        if ( module.ImageUrl != null)
                        {
                            picture.Load(module.ImageUrl);
                        }
                        panel.Controls.Clear();
                        panel.Controls.Add(createHeadlineLabel("Name"), 0, 0);
                        panel.Controls.Add(createLabel(module.Name), 0, 1);

                        panel.Controls.Add(createHeadlineLabel("ID"), 1, 0);
                        panel.Controls.Add(createLabel(module.ID.ToString()), 1, 1);

                        panel.Controls.Add(createHeadlineLabel("Cost"), 2, 0);
                        panel.Controls.Add(createLabel(module.PriceCredits.ToString()), 2, 1);

                        string value = module.FighterSquadrons + " Fighters / " + module.BomberSquadrons + " Bombers / " + module.TorpedoSquadrons + " Torpedoes";
                        panel.Controls.Add(createHeadlineLabel("Squadrons"),3,0);
                        panel.Controls.Add(createLabel(value), 3, 1);

                        ctr.Visible = true;
                    }
                }
                c++; 
            }
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
            FlagImage.Load(Commons.GetFlagURL(selectedShip.Country));
            FlagImage.Tag = selectedShip.Country;
            ShipImage.Load(selectedShip.Images.Small);
            DescriptionBox.Text = selectedShip.Description;
            lblPremium.Text = "Premium: " + Commons.TranslateTrueFalse(selectedShip.Premium); ;
            lblDemo.Text = "Demo: " + Commons.TranslateTrueFalse(selectedShip.DemoProfile);
            lblID.Text = "ID: " + selectedShip.ID.ToString() + " (" + selectedShip.ShipId + ")";
            lblCostCredits.Text = "Cost: " + selectedShip.PriceCredits.ToString();
            lblCostGold.Text = "Cost (gold): " + selectedShip.PriceGold.ToString();
            lblSlots.Text = "Number of slots: " + selectedShip.NumberOfSlots.ToString();
            lblSpecial.Text = "Special: " + Commons.TranslateTrueFalse(selectedShip.Special);
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
            lblDuration1.Text = "";
            lblRange1.Text = "";
            lblCooldown1.Text = "";

            ConsumableControlsHandler handler = new ConsumableControlsHandler(General.Controls);
            handler.HideAll();
            
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.DamageControlParty));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.FastDamageControlParty));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.Repair));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.SpecializedHeal));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.DefAA));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.EmergencyEnginePower));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.SpeedBoost));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.Hydro));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.ShortRangeHydro));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.Smoke));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.CrawlingSmoke));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.ExhaustSmoke));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.ShortBurstSmoke));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.CatapultFighter));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.Radar));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.SpotterPlane));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.MainBatteryReloadBoost));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.TorpedoReloadBoost));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.CAPFighter));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.EngineCooling));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.PatrolFighter));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.AircraftRepair));
            handler.AddConsumable(selectedShip.GetConsumableInfo(ConsumableType.MaxDepth));
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
                    data = module.Profile["engine"]["max_speed"].ToString();
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
            headline.AutoSize = true;
            if ( IsBuilderActive )
            {
                headline.Click += selectPanel_Click;
                headline.Cursor = Cursors.Hand;
            }
            return headline;
        }

        private Label createLabel(string text)
        {
            Label lblText = new Label();
            lblText.Text = text;
            lblText.AutoSize = true;
            if ( IsBuilderActive )
            {
                lblText.Click += selectPanel_Click;
                lblText.Cursor = Cursors.Hand;
            }
            return lblText;
        }

        private void ShipImage_Click(object sender, EventArgs e)
        {
            WGAPI.OpenShipWikipedia(ShipName.Text.ToString());
        }

        private void Consumable_Click(object sender, EventArgs e)
        {
            lblCooldown1.Text = "";
            lblRange1.Text = "";
            lblDuration1.Text = "";
            PictureBox pb = (PictureBox)sender;
            if ( pb.AccessibleName == null || pb.AccessibleName.Equals("")) { return; }

            Enum.TryParse(pb.AccessibleName, out ConsumableType CType);

            if (selectedShip.Consumables != null)
            {
                ConsumableInfo info = selectedShip.Consumables.Find(c => c.Type == CType);
                if (info != null)
                {
                    lblRange1.Text = "Range: " + info.Range.ToString() + " km";
                    lblDuration1.Text = "Duration: " + info.Duration.ToString() + " sec";
                    lblCooldown1.Text = "Cooldown: " + info.Cooldown.ToString() + " sec";

                    
                    lblRange1.Left = pb.Left;
                    lblDuration1.Left = pb.Left;
                    lblCooldown1.Left = pb.Left;
                }
            }
        }

        private void selectPanel_Click(object sender, EventArgs e)
        {
            if ( IsBuilderActive == false ) { return; }

            Panel panel = null;
            if (sender is Panel)
            {
                panel = (Panel)sender;
            } else if (sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;
                panel = (Panel)pb.Parent;

            } else if (sender is TableLayoutPanel)
            {
                TableLayoutPanel tl = (TableLayoutPanel)sender;
                panel = (Panel)tl.Parent;
            } else if ( sender is Label)
            {
                Label lbl = (Label)sender;
                TableLayoutPanel tl = (TableLayoutPanel)lbl.Parent;
                panel = (Panel)tl.Parent;
            } else
            {
                return;
            }
            Console.WriteLine("Clicked: " + panel.Name);
            if ( panel.AccessibleDescription == null || panel.AccessibleDescription.Equals(""))
            {
                panel.AccessibleDescription = "Selected";
            } else
            {
                panel.AccessibleDescription = "";
            }
            panel.Refresh();
        }

        private void selectPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel box = (Panel)sender;
            if ( box.AccessibleDescription == null || box.AccessibleDescription.Equals(""))
            {
                box.BorderStyle = BorderStyle.None;
            } else
            {
                ControlPaint.DrawBorder(e.Graphics, box.ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
            }
        }

        private void Upgrades_Click(object sender, EventArgs e)
        {

        }

        private void rbSlot1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUpgradePanels(GetCheckedSlotNumber());
        }
    }
}
