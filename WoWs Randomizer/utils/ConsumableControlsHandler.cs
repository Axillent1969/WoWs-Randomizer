using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.Control;
using static WoWs_Randomizer.utils.ConsumableTypes;
using WoWs_Randomizer.utils.ship;
using WoWs_Randomizer.objects.consumables;

namespace WoWs_Randomizer.utils
{
    class ConsumableControlsHandler
    {
        private int LastControl = 1;
        private static int MAX_CONTROLS = 8;
        private ControlCollection PlacementCollection = null;
        private Dictionary<ConsumableType, Bitmap> map = new Dictionary<ConsumableType, Bitmap>();
        private Ship selectedShip = null;

        public ConsumableControlsHandler(ControlCollection Controls, Ship SelectedShip)
        {
            this.PlacementCollection = Controls;
            this.selectedShip = SelectedShip;
            LoadBitmaps();
            HideAll();
        }

        public void AddConsumable(ConsumableType CType)
        {
            PictureBox pb = (PictureBox)PlacementCollection["consumable" + LastControl];
            pb.AccessibleName = CType.ToString();

            if ( map.ContainsKey(CType))
            {
                pb.Image = map[CType];
            } else
            {
                pb.Image = null;
            }

            ConsumableInfo info = GetConsumableInfo(CType);
            if ( info != null )
            {
                AddInfoText(info);
            }
            pb.Refresh();
            pb.Visible = true;
            LastControl++;
        }

        private void AddInfoText(ConsumableInfo info)
        {
            if ( info.Range > 0 )
            {
                Label lbl = (Label)PlacementCollection["lblRange" + LastControl];
                lbl.Text = "Range: " + info.Range.ToString() + " km";
                lbl.Visible = true;
            }

            if ( info.Cooldown > 0 )
            {
                Label lbl2 = (Label)PlacementCollection["lblCooldown" + LastControl];
                lbl2.Text = "Cooldown: " + info.Cooldown.ToString() + " sec.";
                lbl2.Visible = true;
            }

            if ( info.Duration > 0 )
            {
                Label lbl3 = (Label)PlacementCollection["lblDuration" + LastControl];
                lbl3.Text = "Duration: " + info.Duration.ToString() + " sec.";
                lbl3.Visible = true;
            }

            if ( info.Charges > 0 )
            {
                Label lbl4 = (Label)PlacementCollection["lblCharges" + LastControl];
                if ( info.Charges == 99)
                {
                    lbl4.Text = "Charges: Unlimited";
                }
                else
                {
                    lbl4.Text = "Charges: " + info.Charges.ToString();
                }
                lbl4.Visible = true;
            }

            if (!info.ExtraInfo.Equals(""))
            {
                Label lbl5 = (Label)PlacementCollection["lblExtra" + LastControl];
                lbl5.Text = info.ExtraInfo;
                lbl5.Visible = true;
            }
        }

        public void HideAll()
        {
            for (int i = 1; i <= MAX_CONTROLS; i++)
            {
                PictureBox pb = (PictureBox)PlacementCollection["consumable" + i];
                pb.Visible = false;

                Label lbl = (Label)PlacementCollection["lblRange" + i];
                lbl.Text = "";
                lbl.Visible = false;

                Label lbl2 = (Label)PlacementCollection["lblCooldown" + i];
                lbl2.Text = "";
                lbl2.Visible = false;

                Label lbl3 = (Label)PlacementCollection["lblDuration" + i];
                lbl3.Text = "";
                lbl3.Visible = false;

                Label lbl4 = (Label)PlacementCollection["lblExtra" + i];
                lbl4.Text = "";
                lbl4.Visible = false;

                Label lbl5 = (Label)PlacementCollection["lblCharges" + i];
                lbl5.Text = "";
                lbl5.Visible = false;

            }
            LastControl = 1;
        }

        private void LoadBitmaps()
        {
            map.Add(ConsumableType.Radar, Properties.Resources.Consumable_PCY020_RadarPremium);
            map.Add(ConsumableType.AircraftRepair, Properties.Resources.Consumable_PCY036_AircraftRepair);
            map.Add(ConsumableType.MaxDepth, Properties.Resources.Consumable_PCY043_Max_Depth);
            map.Add(ConsumableType.Repair, Properties.Resources.Consumable_PCY010_RegenCrew);
            map.Add(ConsumableType.SpecializedHeal, Properties.Resources.Consumable_PCY010_SpecializedHeal_Premium);
            map.Add(ConsumableType.DefAA, Properties.Resources.Consumable_PCY011_AirDefenseDispPremium);
            map.Add(ConsumableType.SpeedBoost, Properties.Resources.Consumable_PCY015_SpeedBoosterPremium);
            map.Add(ConsumableType.Hydro, Properties.Resources.Consumable_PCY016_SonarSearchPremium);
            map.Add(ConsumableType.Smoke, Properties.Resources.Consumable_PCY006_SmokeGenerator);
            map.Add(ConsumableType.CrawlingSmoke, Properties.Resources.Consumable_PCY006_SmokeGeneratorCrawler);
            map.Add(ConsumableType.ExhaustSmoke, Properties.Resources.Consumable_PCY006_SmokeGeneratorOil);
            map.Add(ConsumableType.CatapultFighter, Properties.Resources.Consumable_PCY012_FighterPremium);
            map.Add(ConsumableType.SpotterPlane, Properties.Resources.Consumable_PCY005_Spotter);
            map.Add(ConsumableType.MainBatteryReloadBoost, Properties.Resources.Consumable_PCY022_ArtilleryBoosterPremium);
            map.Add(ConsumableType.TorpedoReloadBoost, Properties.Resources.Consumable_PCY018_TorpedoReloaderPremium);
            map.Add(ConsumableType.CAPFighter, Properties.Resources.Consumable_PCY012_FighterPremium);
            map.Add(ConsumableType.EngineCooling, Properties.Resources.Consumable_PCY015_SpeedBoosterPremium);
            map.Add(ConsumableType.PatrolFighter, Properties.Resources.Consumable_PCY012_FighterPremium);
            map.Add(ConsumableType.DamageControlParty, Properties.Resources.Consumable_PCY009_CrashCrewPremium);
            map.Add(ConsumableType.FastDamageControlParty, Properties.Resources.Consumable_PCY009_CrashCrew_Limited_Premium);
            map.Add(ConsumableType.ShortBurstSmoke, Properties.Resources.Consumable_PCY014_SmokeGenerator_Cycle_Premium);
            map.Add(ConsumableType.EmergencyEnginePower, Properties.Resources.Consumable_PCY015_SpeedBooster_Imp_Premium);
            map.Add(ConsumableType.ShortRangeHydro, Properties.Resources.Consumable_PCY016_SonarSearch_Short_Premium);
        }

        private ConsumableInfo GetConsumableInfo(ConsumableType CType)
        {
            ConsumableInfo info = null;
            if (selectedShip.Consumables != null)
            {
                info = selectedShip.Consumables.Find(c => c.Type == CType);
                if (info != null)
                {
                    //Console.WriteLine("INFO: " + info.Type.ToString());
                    return info;
                }
            }
            //Console.WriteLine("Returning null...");
            return info;
        }
    }
}
