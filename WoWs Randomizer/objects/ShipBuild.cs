using System;
using System.Collections.Generic;

namespace WoWs_Randomizer.utils
{
    [Serializable]
    public class ShipBuild
    {
        public long ID { get; set;}
        public string Name { get; set; }
        public DateTime Modified { get; set; }
        public List<string> Flags { get; set; }
        public List<long> Upgrades { get; set; }
        public List<string> Skills { get; set; }

        public string GameVersion { get; set; }
    }
}
