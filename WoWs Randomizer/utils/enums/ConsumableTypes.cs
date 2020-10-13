using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWs_Randomizer.utils;

namespace WoWs_Randomizer.utils
{
    [Serializable]
    public class ConsumableTypes

    {
        public enum ConsumableType
        {
            AircraftRepair,
            CAPFighter,
            CatapultFighter,
            CrawlingSmoke,
            DefAA,
            EngineCooling,
            ExhaustSmoke,
            Heal,
            Hydro,
            MainBatteryReloadBoost,
            MaxDepth,
            PatrolFighter,
            Radar,
            Repair,
            Smoke,
            SpecializedHeal,
            SpeedBoost,
            SpotterPlane,
            TorpedoReloadBoost
        }
    }
}
