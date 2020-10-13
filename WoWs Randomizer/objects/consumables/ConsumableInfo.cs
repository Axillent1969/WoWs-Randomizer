using System;
using WoWs_Randomizer.utils;
using static WoWs_Randomizer.utils.ConsumableTypes;

namespace WoWs_Randomizer.objects.consumables
{
    [Serializable]
    public class ConsumableInfo
    {
        public double Duration { get; set; }
        public double Cooldown { get; set; }
        public double Range { get; set; }
        public ConsumableType Type { get; set; }

        public ConsumableInfo() { Cooldown = 120; }
    }
}
