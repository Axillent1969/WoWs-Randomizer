using Newtonsoft.Json;
using System;

namespace WoWs_Randomizer.utils.modules
{
    [Serializable]
    public class ModuleAirstrike
    {
        [JsonProperty("AvailableFlights")]
        public long AvailableFlights { get; set; }
        [JsonProperty("NumberOfAttackingFlight")]
        public long NumberOfAttackingFlight { get; set; }
        [JsonProperty("AircraftHP")]
        public long AircraftHP { get; set; }
        [JsonProperty("NumberOfBombs")]
        public long NumberOfBombs { get; set; }
        [JsonProperty("MaxDamage")]
        public long MaxDamage { get; set; }
        [JsonProperty("Penetration")]
        public long Penetration { get; set; }
        [JsonProperty("FireChance")]
        public double FireChance { get; set; }
        [JsonProperty("Range")]
        public double Range { get; set; }
        [JsonProperty("ReloadTime")]
        public long ReloadTime { get; set; }
        [JsonProperty("ImageURL")]
        public string ImageURL { get; set; }
    }
}
