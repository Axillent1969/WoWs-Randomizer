using System;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.objects.ship.profile;

namespace WoWs_Randomizer.utils
{
    class MetricsTableComposer
    {
        public const string SURFACE_DETECTION = "Surface detection";
        public const string AIR_DETECTION = "Air detection";
        public const string GUN_CALIBER = "Gun Caliber";
        public const string RELOAD_MAIN = "Reload Main";
        public const string RANGE_MAIN = "Range";
        public const string FIRECHANCE_MAIN = "Firechance Main";
        public const string TRAVERSE_SPEED = "Traverse speed";
        public const string TRAVERSE_SPEED_180 = "Traverse time 180°";
        public const string RANGE_SECONDARY = "Secondary Range";
        public const string FIRECHANCE_SECONDARY = "Firechance Secondary";
        public const string RELOAOD_SECONDARY = "Reload Secondary";
        public const string TORPEDO_RELOAD = "Torpedo reload";
        public const string TORPEDO_SPEED = "Torpedo speed";
        public const string TORPEDO_RANGE = "Torpedo distance";
        public const string SHIP_HP = "HP";
        public const string SHIP_PREMIUM = "Premium";
        public const string SHIP_SPEED = "Engine/Speed";
        public const string SHIP_CLASS = "Class";
        public const string SHIP_TIER = "Tier";
        public const string FIGHTER_SQUADRONS = "Fighter Squadrons";
        public const string BOMBER_SQUADRONS = "Bomber Squadrons";
        public const string TORPEDO_SQUADRONS = "Torpedo Squadrons";
        public const string TURNING_RADIUS = "Turning radius";
        public const string RUDDER_SHIFT = "Rudder shift";
        public const string DISPERSION = "Maximum dispersion";
        public const string AP_DAMAGE = "Max AP-damage";
        public const string HE_DAMAGE = "Max HE-damage";
        public const string TORPEDO_DAMAGE = "Torpedo damage";

        public static void DrawTable(MetricsExctractor Extractor, MetricsDrawer Table)
        {
            ShipMetrics Metrics = Extractor.GetMetrics();
            Table.SuspendLayout();
            Table.AppendHeadline("General");

            Table.AppendRow(SHIP_CLASS, Metrics.ShipClass);
            Table.AppendRow(SHIP_TIER, Metrics.Tier.ToString());
            Table.AppendRow(SHIP_HP, Metrics.HP.ToString());
            Table.AppendRow(SHIP_PREMIUM, ((Metrics.isPremium) ? "Yes" : "No"));

            if (Metrics.MainCaliberName != null && !Metrics.MainCaliberName.Equals(""))
            {
                Table.AppendHeadline("Main Armament");
                Table.AppendFullRow(Metrics.MainCaliberName);
                Table.AppendRow(GUN_CALIBER, Metrics.MainCaliber.ToString());
                Table.AppendRow(AP_DAMAGE, Metrics.APDamage.ToString());
                Table.AppendRow(HE_DAMAGE, Metrics.HEDamage.ToString());

                Table.AppendRow(RELOAD_MAIN, Metrics.ReloadTimeMain().ToString() + " sec");
                Table.AppendRow(RANGE_MAIN, Metrics.Distance.ToString() + " km");
                Table.AppendRow(DISPERSION, Metrics.Dispersion.ToString() + " m");

                Table.AppendRow(FIRECHANCE_MAIN, Metrics.FireChanceMain.ToString() + " %");
                Table.AppendRow(TRAVERSE_SPEED, Metrics.RotationSpeed().ToString() + " deg/sec");
                Table.AppendRow(TRAVERSE_SPEED_180, Metrics.RotationTime.ToString() + " sec");
            }

            if (Metrics.Secondaries != null)
            {
                Table.AppendHeadline("Secondary Armament(s)");
                Table.AppendRow(RANGE_SECONDARY, Metrics.SecondaryRange.ToString() + " km");
                SecondariesData SecData = Metrics.Secondaries["0"];
                int slot = 0;
                while (SecData != null)
                {
                    Table.AppendFullRow("Slot #" + slot.ToString() + ": " + SecData.Name);
                    Table.AppendRow(RELOAOD_SECONDARY, SecData.ReloadTime().ToString() + " sec", "", "", "Slot" + slot.ToString());
                    Table.AppendRow(FIRECHANCE_SECONDARY, SecData.FireChance.ToString() + " %", "", "", "Slot" + slot.ToString());
                    slot += 1;
                    try
                    {
                        if (Metrics.Secondaries.ContainsKey(slot.ToString()))
                        {
                            SecData = Metrics.Secondaries[slot.ToString()];
                        }
                        else
                        {
                            SecData = null;
                        }
                    }
                    catch (Exception)
                    {
                        SecData = null;
                    }
                }
            }

            if (Metrics.TorpedoReload != 0)
            {
                Table.AppendHeadline("Torpedo Armament");
                Table.AppendRow(TORPEDO_SPEED, Metrics.TorpedoSpeed.ToString() + " knots");
                Table.AppendRow(TORPEDO_DAMAGE, Metrics.TorpedoDamage.ToString());
                Table.AppendRow(TORPEDO_RELOAD, Metrics.TorpedoReload.ToString() + " sec");
                Table.AppendRow(TORPEDO_RANGE, Metrics.TorpedoDistance.ToString() + " km");
            }

            if (Metrics.FighterSquadrons != 0 || Metrics.BomberSquadrons != 0 || Metrics.TorpedoSquadrons != 0)
            {
                Table.AppendHeadline("Plane Armament");
                Table.AppendRow(FIGHTER_SQUADRONS, Metrics.FighterSquadrons.ToString());
                Table.AppendRow(BOMBER_SQUADRONS, Metrics.BomberSquadrons.ToString());
                Table.AppendRow(TORPEDO_SQUADRONS, Metrics.TorpedoSquadrons.ToString());
            }

            Table.AppendHeadline("Manouverability");
            Table.AppendRow(SHIP_SPEED, Metrics.Speed.ToString() + " knots", Metrics.Engine);
            Table.AppendRow(RUDDER_SHIFT, Metrics.RudderTime.ToString() + " sec");
            Table.AppendRow(TURNING_RADIUS, Metrics.TurningRadius.ToString() + " m");

            if (Metrics.SurfaceDetection != 0)
            {
                Table.AppendHeadline("Concealment");
                Table.AppendRow(SURFACE_DETECTION, Metrics.SurfaceDetection.ToString() + " km");
                Table.AppendRow(AIR_DETECTION, Metrics.AirDetection.ToString() + " km");
            }
            Table.ResumeLayout();
        }
    }
}
