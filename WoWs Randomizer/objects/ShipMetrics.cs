using System;
using System.Collections.Generic;
using WoWs_Randomizer.utils.ship.profile;

namespace WoWs_Randomizer.utils
{
    public class ShipMetrics
    {
        // Ship Main Data
        [Exposed()]
        public double HP { get; set; }
        [Exposed()]
        public double Speed { get; set; }
        [Exposed()]
        public string Engine { get; set; }
        public long Tier { get; set; }
        public string ShipClass { get; set; }
        public bool isPremium { get; set; }

        //Torpedo Armament
        [Exposed()]
        public double TorpedoReload { get; set; }
        [Exposed()]
        public double TorpedoSpeed { get; set; }
        [Exposed()]
        public double TorpedoDistance { get; set; }
        [Exposed()]
        public double TorpedoDamage { get; set; }

        // Flight Armament
        [Exposed()]
        public long FighterSquadrons { get; set; }
        [Exposed()]
        public long BomberSquadrons { get; set; }
        [Exposed()]
        public long TorpedoSquadrons { get; set; }

        // Main Aramament
        [Exposed()]
        public double RotationTime { get; set; }
        [Exposed()]
        public double FireChanceMain { get; set; }
        [Exposed()]
        public double FireRateMain { get; set; }
        [Exposed()]
        public double ReloadTimeMain()
        {
            if (FireRateMain != 0)
            {
                double reload = 60 / FireRateMain;
                return Math.Round(reload, 1);
            }
            else
            {
                return 0;
            }
        }

        [Exposed()]
        public long HEDamage { get; set; }
        [Exposed()]
        public long APDamage { get; set; }
        [Exposed("Fire range (main)")]
        public double Distance { get; set; }
        public double DistanceIncrease { get; set; }
        [Exposed()]
        public long MainCaliber { get; set; }
        [Exposed()]
        public string MainCaliberName { get; set; }
        [Exposed()]
        public double Dispersion { get; set; }

        // Secondary Armament(s)
        public Dictionary<string,SecondariesData> Secondaries { get; set; }
        [Exposed("Fire range (secondary)")]
        public double SecondaryRange { get; set; }

        // Concealment
        [Exposed()]
        public double SurfaceDetection { get; set; }
        [Exposed()]
        public double AirDetection { get; set; }

        // Mobility
        [Exposed()]
        public double RudderTime { get; set; }
        [Exposed()]
        public double TurningRadius { get; set; }

        [Exposed()]
        public double RotationSpeed()
        {
            if ( RotationTime != 0 )
            {
                double speed = 180 / RotationTime;
                return Math.Round(speed, 1);
            } else
            {
                return 0;
            }
        }
    }
}
