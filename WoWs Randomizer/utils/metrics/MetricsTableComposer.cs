using System;
using System.Collections.Generic;
using WoWs_Randomizer.objects.ship.profile;
using WoWs_Randomizer.utils.ship.profile;

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
        public const string DISPERSION = "Max dispersion";
        public const string AP_DAMAGE = "Max AP-damage";
        public const string HE_DAMAGE = "Max HE-damage";
        public const string TORPEDO_DAMAGE = "Torpedo damage";
        public const string AA = "Anti Aircraft";
        public const string AA_CALIBER = "Caliber";
        public const string AA_DAMAGE = "Damage";
        public const string SLOT_PREFIX = "Slot #";

        private const string SECTION_GENERAL = "General";
        private const string SECTION_MAIN_ARMAMENT = "Main Armament";
        private const string SECTION_SEC_ARMAMENT = "Secondary Armament(s)";
        private const string SECTION_TORPEDO_ARMAMENT = "Torpedo Armament";
        private const string SECTION_PLANE_ARMAMENT = "Plane Armament";
        private const string SECTION_MANOUVERABILITY = "Manouverability";
        private const string SECTION_CONCEALMENT = "Concealment";
        private const string SUFFIX_SEC = " sec";
        private const string SUFFIX_KM = " km";
        private const string SUFFIX_PCT = " %";
        private const string SUFFIX_M = " m";
        private const string SUFFIX_DEG = " deg/sec";
        private const string SUFFIX_KNOTS = " knots";
        private const string SUFFIX_MM = " mm";


        public static void DrawTable(MetricsExctractor Extractor, MetricsDrawer Table)
        {
            ShipMetrics Metrics = Extractor.GetMetrics();
            Table.SuspendLayout();
            Table.AppendHeadline(SECTION_GENERAL);

            Table.AppendRow(SHIP_CLASS, Metrics.ShipClass);
            Table.AppendRow(SHIP_TIER, Metrics.Tier.ToString());
            Table.AppendRow(SHIP_HP, Metrics.HP.ToString());
            Table.AppendRow(SHIP_PREMIUM, ((Metrics.isPremium) ? "Yes" : "No"));

            if (Metrics.MainCaliberName != null && !Metrics.MainCaliberName.Equals(""))
            {
                Table.AppendHeadline(SECTION_MAIN_ARMAMENT);
                Table.AppendFullRow(Metrics.MainCaliberName);
                Table.AppendRow(GUN_CALIBER, Metrics.MainCaliber.ToString());
                Table.AppendRow(AP_DAMAGE, Metrics.APDamage.ToString());
                Table.AppendRow(HE_DAMAGE, Metrics.HEDamage.ToString());

                Table.AppendRow(RELOAD_MAIN, Metrics.ReloadTimeMain().ToString() + SUFFIX_SEC);
                Table.AppendRow(RANGE_MAIN, Metrics.Distance.ToString() + SUFFIX_KM);
                Table.AppendRow(DISPERSION, Metrics.Dispersion.ToString() + SUFFIX_M);

                Table.AppendRow(FIRECHANCE_MAIN, Metrics.FireChanceMain.ToString() + SUFFIX_PCT);
                Table.AppendRow(TRAVERSE_SPEED, Metrics.RotationSpeed().ToString() + SUFFIX_DEG);
                Table.AppendRow(TRAVERSE_SPEED_180, Metrics.RotationTime.ToString() + SUFFIX_SEC);
            }

            if (Metrics.Secondaries != null)
            {
                Table.AppendHeadline(SECTION_SEC_ARMAMENT);
                Table.AppendRow(RANGE_SECONDARY, Metrics.SecondaryRange.ToString() + SUFFIX_KM);
                SecondariesData SecData = Metrics.Secondaries["0"];
                int slot = 0;
                while (SecData != null)
                {
                    Table.AppendFullRow(SLOT_PREFIX + slot.ToString() + ": " + SecData.Name);
                    Table.AppendRow(RELOAOD_SECONDARY, SecData.ReloadTime().ToString() + SUFFIX_SEC, "", "", "Slot" + slot.ToString());
                    Table.AppendRow(FIRECHANCE_SECONDARY, SecData.FireChance.ToString() + SUFFIX_PCT, "", "", "Slot" + slot.ToString());
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
                Table.AppendHeadline(SECTION_TORPEDO_ARMAMENT);
                Table.AppendRow(TORPEDO_SPEED, Metrics.TorpedoSpeed.ToString() + SUFFIX_KNOTS);
                Table.AppendRow(TORPEDO_DAMAGE, Metrics.TorpedoDamage.ToString());
                Table.AppendRow(TORPEDO_RELOAD, Metrics.TorpedoReload.ToString() + SUFFIX_SEC);
                Table.AppendRow(TORPEDO_RANGE, Metrics.TorpedoDistance.ToString() + SUFFIX_KM);
            }

            if ( Metrics.AntiAircraft != null )
            {
                Table.AppendHeadline(AA);
                Dictionary<string,AntiAircraftMount> mounts = Metrics.AntiAircraft.AAMounts;
                foreach(KeyValuePair<string,AntiAircraftMount> entry in mounts)
                {
                    Table.AppendRow(SLOT_PREFIX + entry.Key.ToString() + ": " + AA_CALIBER, entry.Value.Caliber.ToString() + SUFFIX_MM,entry.Value.Guns.ToString() + " x " + entry.Value.Name,"AA Mount #" + entry.Key.ToString());
                    Table.AppendRow(SLOT_PREFIX + entry.Key.ToString() + ": " + AA_DAMAGE, entry.Value.Damage.ToString(),"Avarage damage per second");
                }

            }

            if (Metrics.FighterSquadrons != 0 || Metrics.BomberSquadrons != 0 || Metrics.TorpedoSquadrons != 0)
            {
                Table.AppendHeadline(SECTION_PLANE_ARMAMENT);
                Table.AppendRow(FIGHTER_SQUADRONS, Metrics.FighterSquadrons.ToString());
                Table.AppendRow(BOMBER_SQUADRONS, Metrics.BomberSquadrons.ToString());
                Table.AppendRow(TORPEDO_SQUADRONS, Metrics.TorpedoSquadrons.ToString());
            }

            Table.AppendHeadline(SECTION_MANOUVERABILITY);
            Table.AppendRow(SHIP_SPEED, Metrics.Speed.ToString() + SUFFIX_KNOTS, Metrics.Engine);
            Table.AppendRow(RUDDER_SHIFT, Metrics.RudderTime.ToString() + SUFFIX_SEC);
            Table.AppendRow(TURNING_RADIUS, Metrics.TurningRadius.ToString() + SUFFIX_M);

            if (Metrics.SurfaceDetection != 0)
            {
                Table.AppendHeadline(SECTION_CONCEALMENT);
                Table.AppendRow(SURFACE_DETECTION, Metrics.SurfaceDetection.ToString() + SUFFIX_KM);
                Table.AppendRow(AIR_DETECTION, Metrics.AirDetection.ToString() + SUFFIX_KM);
            }
            Table.ResumeLayout();
        }
    }
}
