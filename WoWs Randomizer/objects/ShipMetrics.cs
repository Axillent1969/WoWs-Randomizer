using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWs_Randomizer.objects.ship.profile;

namespace WoWs_Randomizer.objects
{
    public class ShipMetrics
    {
        // Ship Main Data
        public double HP { get; set; }
        public double Speed { get; set; }
        public string Engine { get; set; }
        public long Tier { get; set; }
        public string ShipClass { get; set; }
        public bool isPremium { get; set; }

        //Torpedo Armament
        public double TorpedoReload { get; set; }
        public double TorpedoSpeed { get; set; }
        public double TorpedoDistance { get; set; }
        public double TorpedoDamage { get; set; }

        // Flight Armament
        public long FighterSquadrons { get; set; }
        public long BomberSquadrons { get; set; }
        public long TorpedoSquadrons { get; set; }

        // Main Aramament
        public double RotationTime { get; set; }
        public double FireChanceMain { get; set; }
        public double FireRateMain { get; set; }
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

        public long HEDamage { get; set; }
        public long APDamage { get; set; }
        public double Distance { get; set; }
        public double DistanceIncrease { get; set; }
        public long MainCaliber { get; set; }
        public string MainCaliberName { get; set; }
        public double Dispersion { get; set; }

        // Secondary Armament(s)
        public Dictionary<string,SecondariesData> Secondaries { get; set; }
        public double SecondaryRange { get; set; }

        // Concealment
        public double SurfaceDetection { get; set; }
        public double AirDetection { get; set; }

        // Mobility
        public double RudderTime { get; set; }
        public double TurningRadius { get; set; }


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
