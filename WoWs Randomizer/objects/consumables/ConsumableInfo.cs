﻿using System;
using static WoWs_Randomizer.utils.ConsumableTypes;

namespace WoWs_Randomizer.objects.consumables
{
    [Serializable]
    public class ConsumableInfo
    {
        public double Duration { get; set; }
        public double Cooldown { get; set; }
        public double Range { get; set; }

        public int Charges { get; set; }
        public string ExtraInfo { get; set; }

        public ConsumableType Type { get; set; }

        public ConsumableInfo() { Cooldown = 120; }
    }
}
