using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.ship.profile
{
    [Serializable]
    public class Shells
    {
        [JsonProperty("burn_probability")]
        public double? FireChance { get; set; }
        [JsonProperty("damage")]
        public double Damage { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
