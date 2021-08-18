using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.ship.profile
{
    public class AntiAircraftMount
    {
        [JsonProperty("distance")]
        public long Distance { get; set; }
        [JsonProperty("avg_damage")]
        public long Damage { get; set; }
        [JsonProperty("caliber")]
        public long Caliber { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("guns")]
        public long Guns { get; set; }
    }
}
