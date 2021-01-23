using System;
using System.Collections.Generic;
using WoWs_Randomizer.utils.ship.profile;

namespace WoWs_Randomizer.utils
{
    public class ShipMetrics
    {
        // Ship Main Data
        [Exposed(true)]
        public double HP { get; set; }
        [Exposed(true)]
        public double Speed { get; set; }
        [Exposed(true)]
        public string Engine { get; set; }
        public long Tier { get; set; }
        public string ShipClass { get; set; }
        public bool isPremium { get; set; }

        //Torpedo Armament
        [Exposed(true)]
        public double TorpedoReload { get; set; }
        [Exposed(true)]
        public double TorpedoSpeed { get; set; }
        [Exposed(true)]
        public double TorpedoDistance { get; set; }
        [Exposed(true)]
        public double TorpedoDamage { get; set; }

        // Flight Armament
        [Exposed(true)]
        public long FighterSquadrons { get; set; }
        [Exposed(true)]
        public long BomberSquadrons { get; set; }
        [Exposed(true)]
        public long TorpedoSquadrons { get; set; }

        // Main Aramament
        [Exposed(true)]
        public double RotationTime { get; set; }
        [Exposed(true)]
        public double FireChanceMain { get; set; }
        [Exposed(true)]
        public double FireRateMain { get; set; }
        [Exposed(true)]
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

        [Exposed(true)]
        public long HEDamage { get; set; }
        [Exposed(true)]
        public long APDamage { get; set; }
        [Exposed(true)]
        public double Distance { get; set; }
        public double DistanceIncrease { get; set; }
        [Exposed(true)]
        public long MainCaliber { get; set; }
        [Exposed(true)]
        public string MainCaliberName { get; set; }
        [Exposed(true)]
        public double Dispersion { get; set; }

        // Secondary Armament(s)
        public Dictionary<string,SecondariesData> Secondaries { get; set; }
        [Exposed(true)]
        public double SecondaryRange { get; set; }

        // Concealment
        [Exposed(true)]
        public double SurfaceDetection { get; set; }
        [Exposed(true)]
        public double AirDetection { get; set; }

        // Mobility
        [Exposed(true)]
        public double RudderTime { get; set; }
        [Exposed(true)]
        public double TurningRadius { get; set; }

        [Exposed(true)]
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
