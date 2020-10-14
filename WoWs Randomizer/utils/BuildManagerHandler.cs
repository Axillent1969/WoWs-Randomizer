using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WoWs_Randomizer.objects.consumables;
using WoWs_Randomizer.utils;

namespace WoWs_Randomizer.utils
{
    public class BuildManagerHandler
    {
        private TableLayoutPanel ShipMetricsTable = null;
        private ShipMetrics Metrics = null;
        private bool Animate = true;
        private bool KeepTransparancy = false;
        private Dictionary<string,double> selectedSkillsUpgrades = new Dictionary<string, double>(); // Currently only used for secondaries count
        private Dictionary<string, double> selectedRudderSkills = new Dictionary<string, double>();

        public BuildManagerHandler(TableLayoutPanel ShipMetricsTable, ShipMetrics originalMetrics)
        {
            this.ShipMetricsTable = ShipMetricsTable;
            Metrics = originalMetrics;
        }

        public void PerformAnimation(bool status) { Animate = status; }
        public void KeepBackgroundTransparent(bool transparent) { KeepTransparancy = transparent; }

        public void ApplyAll(List<string> idList)
        {
            foreach (string id in idList)
            {
                ApplyValue(id);
            }
        }

        public void ApplyAll(List<long> idList)
        {
            foreach (long id in idList)
            {
                ApplyValue(id.ToString());
            }
        }

        public void ApplyValue(string accessibleName)
        {
            
            // Captain Skills
            if (accessibleName.Equals("Concealment Expert") || accessibleName.Equals("4265791408"))
            {
                ChangeConcealment(0.1);

            }
            else if (accessibleName.Equals("Advanced Firing Training"))
            {
                Label caliber = GetValueLabel(MetricsTableComposer.GUN_CALIBER);
                if (caliber != null)
                {
                    int caliberSize = int.Parse(caliber.Text.ToString());
                    if (caliberSize <= 139)
                    {
                        ChangeMainGunRange(0.2);
                    }
                }
                selectedSkillsUpgrades.Add(accessibleName,0.2);
                ChangeSecondaryRanges(0.2);

            }
            else if (accessibleName.Equals("Inertia Fuse for HE Shells"))
            {
                ChangeFirechanceMain(-0.5);
                ChangeFirechanceSecondaries(-0.5);

            }
            else if (accessibleName.Equals("Demolition Expert"))
            {
                ChangeFirechanceMainFixedValue(2);
                ChangeFirechanceSecondariesFixedValue(2);

            }
            else if (accessibleName.Equals("Basic Firing Training"))
            {
                Label caliber = GetValueLabel(MetricsTableComposer.GUN_CALIBER);
                if (caliber != null)
                {
                    int caliberSize = int.Parse(caliber.Text.ToString());
                    if (caliberSize <= 139)
                    {
                        ChangeReloadMain(-0.1);
                    }
                }
                ChangeReloadSecondaries(-0.1);

            }
            else if (accessibleName.Equals("Torpedo Armament Expertise"))
            {
                ChangeTorpedoReload(-0.1);

            }
            else if (accessibleName.Equals("Survivability Expert"))
            {
                ChangeShipHP(Metrics.Tier * 350);

            }
            else if (accessibleName.Equals("Torpedo Acceleration"))
            {
                ChangeTorpedoSpeed(5);
                ChangeTorpedoDistance(-0.2);
            }
            else if (accessibleName.Equals("Expert Marksman"))
            {
                Label caliber = GetValueLabel(MetricsTableComposer.GUN_CALIBER);
                if (caliber == null) { return; }

                int caliberSize = int.Parse(caliber.Text.ToString());
                double change = 2.5;
                if (caliberSize > 139)
                {
                    change = 0.7;
                }
                ChangeTurretTraverseFixedValue(change);
            }
            else if (accessibleName.Equals("Direction Center for Fighters"))
            {
                Label fs = GetValueLabel(MetricsTableComposer.FIGHTER_SQUADRONS);
                if (fs != null)
                {
                    int fighers = int.Parse(fs.Text.ToString());
                    fighers += 1;

                    fs.Text = fighers.ToString();
                    AnimateLabel(fs, GetFinalColor(MetricsTableComposer.FIGHTER_SQUADRONS, fighers));
                }
            }
            else if (accessibleName.Equals("4282216368"))
            {
                //Flag
                ChangeReloadSecondaries(-0.05);
                selectedSkillsUpgrades.Add(accessibleName,0.05);
                ChangeSecondaryRanges(0.05);
            }
            else if (accessibleName.Equals("4289556400"))
            {
                //Flag
                Label range = GetValueLabel(MetricsTableComposer.SHIP_SPEED);
                double distance = double.Parse(range.Text.ToString().Split(' ')[0]);
                double totalIncrease = Math.Round(Metrics.Speed * 0.05, 1);
                distance += totalIncrease;
                range.Text = distance.ToString() + " knots";
                AnimateLabel(range, GetFinalColor(MetricsTableComposer.SHIP_SPEED, distance));
            }
            else if (accessibleName.Equals("4276973488") || accessibleName.Equals("4275924912"))
            {
                //Flags
                /*Consumable Upgrade = Program.Flags.Find(x => x.ID == long.Parse(accessibleName));
                
                if (Upgrade != null)
                {
                    foreach (KeyValuePair<string, ConsumableProfile> Perk in Upgrade.Profile)
                    {
                        Console.WriteLine(Perk.Key + " = " + Perk.Value.Value);
                        double value = GetAddPerkValue(Perk.Key, Perk.Value.Value);
                        //ExecutePerk(Perk.Key, value);
                    }
                }
                */
                Label caliber = GetValueLabel(MetricsTableComposer.GUN_CALIBER);
                if (caliber != null)
                {
                    double pct = 1;
                    int caliberSize = int.Parse(caliber.Text.ToString());
                    if (caliberSize <= 160)
                    {
                        pct = 0.5;
                    }
                    ChangeFirechanceMainFixedValue(pct);
                    ChangeFirechanceSecondariesFixedValue(1);
                }
            } else
            {
                long upgradeId = 0;
                bool result = long.TryParse(accessibleName, out upgradeId); 

                if ( result && upgradeId > 0)
                {
                    Consumable Upgrade = Program.Upgrades.Find(x => x.ID == upgradeId);
                    if (Upgrade != null)
                    {
                        //Console.WriteLine(Upgrade.ID);
                        foreach (KeyValuePair<string, ConsumableProfile> Perk in Upgrade.Profile)
                        {
                            double value = GetPerkValueToAdd(Perk.Key, Perk.Value.Value);
                            if (Perk.Key == "GSMaxDist")
                            {
                                selectedSkillsUpgrades.Add(accessibleName, value);
                            } else if ( Perk.Key == "SGRudderTime")
                            {
                                selectedRudderSkills.Add(accessibleName, value);
                            }
                            ExecutePerk(Perk.Key, value);
                        }
                    }
                }
            }
        }

        public void RemoveValue(string accessibleName)
        {
            if (accessibleName.Equals("Concealment Expert") || accessibleName.Equals("4265791408"))
            {
                ChangeConcealment(-0.1);

            }
            else if (accessibleName.Equals("Advanced Firing Training"))
            {
                Label caliber = GetValueLabel("Gun Caliber");
                if (caliber != null)
                {
                    int caliberSize = int.Parse(caliber.Text.ToString());
                    if (caliberSize <= 139)
                    {
                        ChangeMainGunRange(-0.2);
                    }
                }
                selectedSkillsUpgrades.Remove(accessibleName);
                ChangeSecondaryRanges(-0.2);

            }
            else if (accessibleName.Equals("Inertia Fuse for HE Shells"))
            {
                ChangeFirechanceMain(0.5);
                ChangeFirechanceSecondaries(0.5);

            }
            else if (accessibleName.Equals("Demolition Expert"))
            {
                ChangeFirechanceMainFixedValue(-2);
                ChangeFirechanceSecondariesFixedValue(-2);

            }
            else if (accessibleName.Equals("Basic Firing Training"))
            {
                Label caliber = GetValueLabel(MetricsTableComposer.GUN_CALIBER);
                if (caliber != null)
                {
                    int caliberSize = int.Parse(caliber.Text.ToString());
                    if (caliberSize <= 139)
                    {
                        ChangeReloadMain(0.1);
                    }
                }
                ChangeReloadSecondaries(0.1);

            }
            else if (accessibleName.Equals("Torpedo Armament Expertise"))
            {
                ChangeTorpedoReload(0.1);

            }
            else if (accessibleName.Equals("Survivability Expert"))
            {
                ChangeShipHP(-(Metrics.Tier * 350));

            }
            else if (accessibleName.Equals("Torpedo Acceleration"))
            {
                ChangeTorpedoSpeed(-5);
                ChangeTorpedoDistance(0.2);
            }
            else if (accessibleName.Equals("Expert Marksman"))
            {
                Label caliber = GetValueLabel(MetricsTableComposer.GUN_CALIBER);
                if (caliber != null)
                {
                    int caliberSize = int.Parse(caliber.Text.ToString());
                    double change = -2.5;
                    if (caliberSize > 139)
                    {
                        change = -0.7;
                    }
                    ChangeTurretTraverseFixedValue(change);
                }
            }
            else if (accessibleName.Equals("Direction Center for Fighters"))
            {
                Label fs = GetValueLabel(MetricsTableComposer.FIGHTER_SQUADRONS);
                if (fs != null)
                {
                    int fighers = int.Parse(fs.Text.ToString());
                    fighers -= 1;

                    fs.Text = fighers.ToString();
                    AnimateLabel(fs, GetFinalColor(MetricsTableComposer.FIGHTER_SQUADRONS, fighers));
                }
            }
            else if (accessibleName.Equals("4282216368"))
            {
                //Flag
                ChangeReloadSecondaries(0.05);
                selectedSkillsUpgrades.Remove(accessibleName);
                ChangeSecondaryRanges(-0.05);
            }
            else if (accessibleName.Equals("4289556400") || accessibleName.Equals("4275924912"))
            {
                //Flags
                Label range = GetValueLabel(MetricsTableComposer.SHIP_SPEED);
                double distance = double.Parse(range.Text.ToString().Split(' ')[0]);
                double totalIncrease = Math.Round(Metrics.Speed * 0.05, 1);
                distance -= totalIncrease;
                range.Text = distance.ToString() + " knots";
                AnimateLabel(range, GetFinalColor(MetricsTableComposer.SHIP_SPEED, distance));
            }
            else if (accessibleName.Equals("4276973488"))
            {
                Label caliber = GetValueLabel(MetricsTableComposer.GUN_CALIBER);
                if (caliber != null)
                {
                    double pct = -1;
                    int caliberSize = int.Parse(caliber.Text.ToString());
                    if (caliberSize <= 160)
                    {
                        pct = -0.5;
                    }
                    ChangeFirechanceMainFixedValue(pct);
                    ChangeFirechanceSecondariesFixedValue(-1);
                }
            }
            else
            {
                long upgradeId = 0;
                bool result = long.TryParse(accessibleName, out upgradeId);

                if (result && upgradeId > 0)
                {
                    Consumable Upgrade = Program.Upgrades.Find(x => x.ID == upgradeId);
                    if (Upgrade != null)
                    {
                        foreach (KeyValuePair<string, ConsumableProfile> Perk in Upgrade.Profile)
                        {
                            double value = GetPerkValueToRemove(Perk.Key, Perk.Value.Value);
                            if ( Perk.Key == "GSMaxDist")
                            {
                                selectedSkillsUpgrades.Remove(accessibleName);
                            } else if ( Perk.Key == "SGRudderTime") {
                                selectedRudderSkills.Remove(accessibleName);
                            }
                            ExecutePerk(Perk.Key, value);
                        }
                    }
                }
            }
        }

        private List<Label> GetAllValueLabels(string labelName)
        {
            List<Label> list = new List<Label>();
            for (var row = 0; row < ShipMetricsTable.RowCount; row++)
            {
                Label label = (Label)ShipMetricsTable.GetControlFromPosition(0, row);
                Label value = (Label)ShipMetricsTable.GetControlFromPosition(1, row);
                if (label.Text.ToString().Equals(labelName))
                {
                    list.Add(value);
                }
            }
            return list;
        }

        private Label GetValueLabel(string labelName)
        {
            for (var row = 0; row < ShipMetricsTable.RowCount; row++)
            {
                Label label = (Label)ShipMetricsTable.GetControlFromPosition(0, row);
                Label value = (Label)ShipMetricsTable.GetControlFromPosition(1, row);
                if (label.Text.ToString().Equals(labelName))
                {
                    return value;
                }
            }
            return null;
        }

        private Color GetFinalColor(string accessibleName, double value, double metricsvalue = -1)
        {
            if (KeepTransparancy == true)
            {
                return Color.Transparent;
            }
            double mvalue = 0;
            if (metricsvalue == -1)
            {
                Dictionary<string, double> metricsLookup = new Dictionary<string, double>();
                metricsLookup.Add(MetricsTableComposer.FIRECHANCE_MAIN, Metrics.FireChanceMain);
                metricsLookup.Add(MetricsTableComposer.RANGE_MAIN, Metrics.Distance);
                metricsLookup.Add(MetricsTableComposer.AIR_DETECTION, Metrics.AirDetection);
                metricsLookup.Add(MetricsTableComposer.SURFACE_DETECTION, Metrics.SurfaceDetection);
                metricsLookup.Add(MetricsTableComposer.RANGE_SECONDARY, Metrics.SecondaryRange);
                metricsLookup.Add(MetricsTableComposer.RELOAD_MAIN, Metrics.ReloadTimeMain());
                metricsLookup.Add(MetricsTableComposer.TORPEDO_RELOAD, Metrics.TorpedoReload);
                metricsLookup.Add(MetricsTableComposer.SHIP_HP, Metrics.HP);
                metricsLookup.Add(MetricsTableComposer.TORPEDO_SPEED, Metrics.TorpedoSpeed);
                metricsLookup.Add(MetricsTableComposer.TORPEDO_RANGE, Metrics.TorpedoDistance);
                metricsLookup.Add(MetricsTableComposer.TRAVERSE_SPEED, Metrics.RotationSpeed());
                metricsLookup.Add(MetricsTableComposer.FIGHTER_SQUADRONS, Metrics.FighterSquadrons);
                metricsLookup.Add(MetricsTableComposer.SHIP_SPEED, Metrics.Speed);
                metricsLookup.Add(MetricsTableComposer.RUDDER_SHIFT, Metrics.RudderTime);

                mvalue = metricsLookup[accessibleName];
            }
            else
            {
                mvalue = metricsvalue;
            }

            List<string> lowerBetter = new List<string>();
            List<string> higherBetter = new List<string>();
            lowerBetter.Add(MetricsTableComposer.SURFACE_DETECTION);
            lowerBetter.Add(MetricsTableComposer.AIR_DETECTION);
            lowerBetter.Add(MetricsTableComposer.RELOAD_MAIN);
            lowerBetter.Add(MetricsTableComposer.RELOAOD_SECONDARY);
            lowerBetter.Add(MetricsTableComposer.TORPEDO_RELOAD);
            lowerBetter.Add(MetricsTableComposer.RUDDER_SHIFT);
            lowerBetter.Add(MetricsTableComposer.TURNING_RADIUS);

            higherBetter.Add(MetricsTableComposer.RANGE_MAIN);
            higherBetter.Add(MetricsTableComposer.RANGE_SECONDARY);
            higherBetter.Add(MetricsTableComposer.FIRECHANCE_MAIN);
            higherBetter.Add(MetricsTableComposer.FIRECHANCE_SECONDARY);
            higherBetter.Add(MetricsTableComposer.SHIP_HP);
            higherBetter.Add(MetricsTableComposer.TORPEDO_SPEED);
            higherBetter.Add(MetricsTableComposer.TORPEDO_RANGE);
            higherBetter.Add(MetricsTableComposer.TRAVERSE_SPEED);
            higherBetter.Add(MetricsTableComposer.FIGHTER_SQUADRONS);
            higherBetter.Add(MetricsTableComposer.SHIP_SPEED);
            

            if (value == mvalue || Math.Round(value, 1) == Math.Round(mvalue, 1))
            {
                return Color.Transparent;
            }
            else if ((lowerBetter.Contains(accessibleName) && value < mvalue) || (higherBetter.Contains(accessibleName) && value > mvalue))
            {
                return Color.LightGreen;
            }
            else
            {
                return Color.LightCoral;
            }
        }

        private void AnimateLabel(Label label, Color FinalColor)
        {
            if (Animate)
            {
                for (var i = 0; i < 3; i++)
                {
                    label.BackColor = Color.LightYellow;
                    label.Refresh();
                    Thread.Sleep(75);
                    label.BackColor = Color.LightBlue;
                    label.Refresh();
                    Thread.Sleep(75);
                }
            }
            label.BackColor = FinalColor;
            label.Refresh();
        }

        private void ChangeConcealment(double percent)
        {
            /*
            Label surfaceDetection = GetValueLabel(MetricsTableComposer.SURFACE_DETECTION);
            Label airDetection = GetValueLabel(MetricsTableComposer.AIR_DETECTION);

            double surfaceDetValue = ExtractValue(surfaceDetection);
            double airDetValue = ExtractValue(airDetection);

            double baseValueSurface = Math.Round(Metrics.SurfaceDetection * percent, 1);
            double baseValueAir = Math.Round(Metrics.AirDetection * percent, 1);

            surfaceDetValue = surfaceDetValue - baseValueSurface;
            airDetValue = airDetValue - baseValueAir;

            surfaceDetection.Text = surfaceDetValue.ToString();
            AnimateLabel(surfaceDetection, GetFinalColor(MetricsTableComposer.SURFACE_DETECTION, surfaceDetValue));
            airDetection.Text = airDetValue.ToString();
            AnimateLabel(airDetection, GetFinalColor(MetricsTableComposer.AIR_DETECTION, airDetValue));
            */
            ChangeConcealmentAir(percent);
            ChangeConcealmentSurface(percent);
        }

        private void ChangeConcealmentAir(double percent)
        {
            Label airDetection = GetValueLabel(MetricsTableComposer.AIR_DETECTION);

            double airDetValue = ExtractValue(airDetection);

            double baseValueAir = Math.Round(Metrics.AirDetection * percent, 1);

            airDetValue = airDetValue - baseValueAir;

            airDetection.Text = airDetValue.ToString();
            AnimateLabel(airDetection, GetFinalColor(MetricsTableComposer.AIR_DETECTION, airDetValue));
        }

        private void ChangeConcealmentSurface(double percent)
        {
            Label surfaceDetection = GetValueLabel(MetricsTableComposer.SURFACE_DETECTION);

            double surfaceDetValue = ExtractValue(surfaceDetection);

            double baseValueSurface = Math.Round(Metrics.SurfaceDetection * percent, 1);

            surfaceDetValue = surfaceDetValue - baseValueSurface;

            surfaceDetection.Text = surfaceDetValue.ToString();
            AnimateLabel(surfaceDetection, GetFinalColor(MetricsTableComposer.SURFACE_DETECTION, surfaceDetValue));
        }

        private void ChangeMainGunRange(double percent)
        {
            Label range = GetValueLabel(MetricsTableComposer.RANGE_MAIN);
            if (range != null)
            {
                double distance = double.Parse(range.Text.ToString().Split(' ')[0]);
                double totalIncrease = Math.Round(Metrics.Distance * percent, 1);
                distance += totalIncrease;
                range.Text = distance.ToString();
                AnimateLabel(range, GetFinalColor(MetricsTableComposer.RANGE_MAIN, distance));
            }
        }

        private void ChangeSecondaryRanges(double percent)
        {
            List<Label> AllSecondaries = GetAllValueLabels(MetricsTableComposer.RANGE_SECONDARY);
            foreach (Label lbl in AllSecondaries)
            {
                double current = Metrics.SecondaryRange;

                foreach(KeyValuePair<string,double> entry in selectedSkillsUpgrades)
                {
                    double addDistance = Math.Round(current * entry.Value, 1);
                    current += addDistance;
                }
                lbl.Text = current.ToString() + " km";
                AnimateLabel(lbl, GetFinalColor(MetricsTableComposer.RANGE_SECONDARY, current));
            }
        }

        private void ChangeFirechanceMain(double percent)
        {
            Label fcMain = GetValueLabel(MetricsTableComposer.FIRECHANCE_MAIN);
            if (fcMain != null)
            {
                double fc = double.Parse(fcMain.Text.ToString().Split(' ')[0]);
                double fcChange = Math.Round(Metrics.FireChanceMain * percent, 1);
                fc += fcChange;
                fcMain.Text = fc.ToString() + " %";
                AnimateLabel(fcMain, GetFinalColor(MetricsTableComposer.FIRECHANCE_MAIN, fc));
            }
        }

        private void ChangeFirechanceMainFixedValue(double fixedvalue)
        {
            Label fcMain = GetValueLabel(MetricsTableComposer.FIRECHANCE_MAIN);
            if (fcMain != null)
            {
                double fc = double.Parse(fcMain.Text.ToString().Split(' ')[0]);
                fc += fixedvalue;
                fcMain.Text = fc.ToString() + " %";
                AnimateLabel(fcMain, GetFinalColor(MetricsTableComposer.FIRECHANCE_MAIN, fc));
            }
        }

        private void ChangeFirechanceSecondaries(double percent)
        {
            List<Label> Secondaries = GetAllValueLabels(MetricsTableComposer.FIRECHANCE_SECONDARY);
            int slot = 0;
            foreach (Label fcSecLbl in Secondaries)
            {
                double fcSec = ExtractValue(fcSecLbl);
                double fcSecChange = Math.Round(Metrics.Secondaries[slot.ToString()].FireChance * percent, 1);
                fcSec += fcSecChange;
                fcSecLbl.Text = fcSec.ToString() + " %";
                AnimateLabel(fcSecLbl, GetFinalColor(MetricsTableComposer.FIRECHANCE_SECONDARY, fcSec, Metrics.Secondaries[slot.ToString()].FireChance));
                slot++;
            }
        }

        private void ChangeFirechanceSecondariesFixedValue(double fixedvalue)
        {
            List<Label> Secondaries = GetAllValueLabels(MetricsTableComposer.FIRECHANCE_SECONDARY);
            int slot = 0;
            foreach (Label fcSecLbl in Secondaries)
            {
                double fcSec = ExtractValue(fcSecLbl);
                fcSec += fixedvalue;
                fcSecLbl.Text = fcSec.ToString() + " %";
                AnimateLabel(fcSecLbl, GetFinalColor(MetricsTableComposer.FIRECHANCE_SECONDARY, fcSec, Metrics.Secondaries[slot.ToString()].FireChance));
                slot++;
            }
        }

        private void ChangeReloadMain(double percent)
        {
            Label reload = GetValueLabel(MetricsTableComposer.RELOAD_MAIN);
            if (reload != null)
            {
                double reloadTime = ExtractValue(reload);
                double totalIncrease = Math.Round(Metrics.ReloadTimeMain() * percent, 1);
                reloadTime += totalIncrease;
                reload.Text = reloadTime.ToString() + " sec";
                AnimateLabel(reload, GetFinalColor(MetricsTableComposer.RELOAD_MAIN, reloadTime));
            }
        }

        private void ChangeReloadSecondaries(double percent)
        {
            List<Label> Secondaries = GetAllValueLabels(MetricsTableComposer.RELOAOD_SECONDARY);
            int slot = 0;
            foreach (Label fcSecLbl in Secondaries)
            {
                double fcSec = ExtractValue(fcSecLbl);
                double fcSecChange = Math.Round(Metrics.Secondaries[slot.ToString()].ReloadTime() * percent, 1);
                fcSec += fcSecChange;
                fcSecLbl.Text = fcSec.ToString() + " sec";
                AnimateLabel(fcSecLbl, GetFinalColor(MetricsTableComposer.RELOAOD_SECONDARY, fcSec, Metrics.Secondaries[slot.ToString()].ReloadTime()));
                slot++;
            }
        }

        private void ChangeTorpedoReload(double percent)
        {
            Label torp = GetValueLabel(MetricsTableComposer.TORPEDO_RELOAD);
            if (torp == null) { return; }
            double reload = ExtractValue(torp);
            double torpChange = Math.Round(Metrics.TorpedoReload * percent, 1);
            reload += torpChange;
            torp.Text = reload.ToString() + " sec";
            AnimateLabel(torp, GetFinalColor(MetricsTableComposer.TORPEDO_RELOAD, reload));
        }

        private void ChangeShipHP(double fixedValue)
        {
            Label hp = GetValueLabel(MetricsTableComposer.SHIP_HP);
            double hpValue = double.Parse(hp.Text.ToString());
            hpValue += fixedValue;
            hp.Text = hpValue.ToString();
            AnimateLabel(hp, GetFinalColor(MetricsTableComposer.SHIP_HP, hpValue));
        }

        private void ChangeTorpedoSpeed(double fixedValue)
        {
            Label torpSpeedLbl = GetValueLabel(MetricsTableComposer.TORPEDO_SPEED);

            if (torpSpeedLbl == null) { return; }

            double currentSpeed = double.Parse(torpSpeedLbl.Text.ToString().Split(' ')[0]);

            currentSpeed += fixedValue;

            torpSpeedLbl.Text = currentSpeed.ToString() + " knots";
            AnimateLabel(torpSpeedLbl, GetFinalColor(MetricsTableComposer.TORPEDO_SPEED, currentSpeed));
        }

        private void ChangeTorpedoDistance(double percent)
        {
            Label torpRangeLbl = GetValueLabel(MetricsTableComposer.TORPEDO_RANGE);

            if (torpRangeLbl == null) { return; }
            double rangeChange = Math.Round(Metrics.TorpedoDistance * percent, 1);

            double currentRange = double.Parse(torpRangeLbl.Text.ToString().Split(' ')[0]);

            currentRange += rangeChange;

            torpRangeLbl.Text = currentRange.ToString() + " km";
            AnimateLabel(torpRangeLbl, GetFinalColor(MetricsTableComposer.TORPEDO_RANGE, currentRange));
        }

        private void ChangeTurretTraverseFixedValue(double fixedValue)
        {

            Label travSpeedLbl = GetValueLabel(MetricsTableComposer.TRAVERSE_SPEED);
            Label travTimeLbl = GetValueLabel(MetricsTableComposer.TRAVERSE_SPEED_180);

            if (travSpeedLbl == null) { return; }

            double currentSpeed = double.Parse(travSpeedLbl.Text.ToString().Split(' ')[0]);
            double currentTime = double.Parse(travTimeLbl.Text.ToString().Split(' ')[0]);

            currentSpeed += fixedValue;
            currentTime = Math.Round(180 / currentSpeed, 1);

            travSpeedLbl.Text = currentSpeed.ToString() + " deg/sec";
            AnimateLabel(travSpeedLbl, GetFinalColor(MetricsTableComposer.TRAVERSE_SPEED, currentSpeed));
            travTimeLbl.Text = currentTime.ToString() + " sec";
            AnimateLabel(travTimeLbl, GetFinalColor(MetricsTableComposer.TRAVERSE_SPEED, currentSpeed));
        }

        private void ChangeTurretTraverse(double percent)
        {
            Label travSpeedLbl = GetValueLabel(MetricsTableComposer.TRAVERSE_SPEED);
            Label travTimeLbl = GetValueLabel(MetricsTableComposer.TRAVERSE_SPEED_180);

            if (travSpeedLbl == null) { return; }

            double currentSpeed = double.Parse(travSpeedLbl.Text.ToString().Split(' ')[0]);
            double currentTime = double.Parse(travTimeLbl.Text.ToString().Split(' ')[0]);

            currentSpeed += Math.Round(Metrics.RotationSpeed() * percent, 1);
            currentTime = Math.Round(180 / currentSpeed, 1);

            travSpeedLbl.Text = currentSpeed.ToString() + " deg/sec";
            AnimateLabel(travSpeedLbl, GetFinalColor(MetricsTableComposer.TRAVERSE_SPEED, currentSpeed));
            travTimeLbl.Text = currentTime.ToString() + " sec";
            AnimateLabel(travTimeLbl, GetFinalColor(MetricsTableComposer.TRAVERSE_SPEED, currentSpeed));
        }

        private void ChangeRudderShiftTime(double percent)
        {
            Label rudderShiftTimeLbl = GetValueLabel(MetricsTableComposer.RUDDER_SHIFT);
            if ( rudderShiftTimeLbl == null ) { return; }

            double baseSpeed = Metrics.RudderTime;
            foreach(KeyValuePair<string,double> entry in selectedRudderSkills)
            {
                baseSpeed += Math.Round(baseSpeed * entry.Value, 1);
            }
            rudderShiftTimeLbl.Text = baseSpeed.ToString() + " sec";
            AnimateLabel(rudderShiftTimeLbl, GetFinalColor(MetricsTableComposer.RUDDER_SHIFT, baseSpeed));
        }

        private double ExtractValue(Label lbl)
        {
            double current = 0;
            string unit = "";
            if (lbl.Text.ToString().Contains(" "))
            {
                current = double.Parse(lbl.Text.ToString().Split(' ')[0]);
                unit = lbl.Text.ToString().Split(' ')[1];
            }
            else
            {
                current = double.Parse(lbl.Text.ToString());
            }
            return current;
        }

        private double GetPerkValueToAdd(string perkName, double value)
        {
            if ( perkName.Equals("visibilityDistCoeff"))
            {
                return 1 - value;
            } else if ( perkName.Equals("torpedoSpeedMultiplier"))
            {
                double val = Metrics.TorpedoSpeed * (value - 1);
                return val;
            }
            return value - 1;
        }

        private double GetPerkValueToRemove(string perkName, double value)
        {
            if ( perkName.Equals("visibilityDistCoeff"))
            {
                return value - 1;
            } else if ( perkName.Equals("torpedoSpeedMultiplier"))
            {
                double val = Metrics.TorpedoSpeed * (value - 1);
                return -val;
            }
            return 1 - value;
        }

        private void ExecutePerk(string perkName, double value)
        {
            if ( perkName.Equals("GMRotationSpeed"))
            {
                ChangeTurretTraverse(value);
            } else if ( perkName.Equals("GSShotDelay"))
            {
                ChangeReloadSecondaries(value);
            } else if ( perkName.Equals("GMShotDelay"))
            {
                ChangeReloadMain(value);
            } else if ( perkName.Equals("GMMaxDist"))
            {
                ChangeMainGunRange(value);
            } else if ( perkName.Equals("visibilityDistCoeff"))
            {
                ChangeConcealment(value);
            } else if ( perkName.Equals("GTShotDelay"))
            {
                ChangeTorpedoReload(value);
            } else if ( perkName.Equals("torpedoSpeedMultiplier"))
            {
                ChangeTorpedoSpeed(value);
            } else if ( perkName.Equals("GSMaxDist"))
            {
                ChangeSecondaryRanges(value);
            } else if ( perkName.Equals("SGRudderTime"))
            {
                ChangeRudderShiftTime(value);
            } else if ( perkName.Equals("visibilityFactorByPlane")) 
            {
                ChangeConcealmentAir(value);
            } else if ( perkName.Equals("visibilityFactor"))
            {
                ChangeConcealmentSurface(value);
            } else
            {
            }
        }
    }
}
