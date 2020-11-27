using System;

namespace WoWs_Randomizer.utils.modules
{
    [Serializable]
    class ModuleTorpedoBomber
    {
        public double Distance { get; set; }
        public string Name { get; set; }
        public int CruiseSpeed { get; set; }
        public int MaxDamage { get; set; }
        public int TorpedoSpeed { get; set; }
        public int Health { get; set; }

    }
}
