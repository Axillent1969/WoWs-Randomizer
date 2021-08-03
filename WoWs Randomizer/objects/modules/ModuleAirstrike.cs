using System;

namespace WoWs_Randomizer.objects.modules
{
    [Serializable]
    public class ModuleAirstrike
    {
        public long AvailableFlights { get; set; }
        public long NumberOfAttackingFlight { get; set; }
        public long AircraftHP { get; set; }
        public long NumberOfBombs { get; set; }
        public long MaxDamage { get; set; }
        public long Penetration { get; set; }
        public double FireChance { get; set; }
        public double Range { get; set; }
        public long ReloadTime { get; set; }
        public string ImageURL { get; set; }
    }
}
