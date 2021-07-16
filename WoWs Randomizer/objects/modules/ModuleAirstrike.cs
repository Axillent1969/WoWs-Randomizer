using System;

namespace WoWs_Randomizer.objects.modules
{
    [Serializable]
    class ModuleAirstrike
    {
        public long AvailableFlights { get; set; }
        public long NumberOfAttackingFlight { get; set; }
        public long AircraftHP { get; set; }
        public long NumberOfBombs { get; set; }
        public long MaxDamage { get; set; }
        public long Penetration { get; set; }
        public long FireChance { get; set; }
        public long Range { get; set; }
        public long ReloadTime { get; set; }
    }
}
