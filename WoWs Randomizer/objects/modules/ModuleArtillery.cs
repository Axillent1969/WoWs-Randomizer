﻿using System;

namespace WoWs_Randomizer.utils.modules
{
    [Serializable]
    class ModuleArtillery
    {
        public double RotationTime { get; set; }
        public long APDamage { get; set; }
        public long HEDamage { get; set; }
        public double GunRate { get; set; }

    }
}
