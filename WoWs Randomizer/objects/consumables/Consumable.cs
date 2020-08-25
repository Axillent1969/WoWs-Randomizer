using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.upgrades
{
    [Serializable]
    public class Consumable
    {
        [JsonProperty("profile")]
        public Dictionary<string,ConsumableProfile> Profile { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price_gold")]
        public long Gold { get; set; }
        [JsonProperty("image")]
        public string ImageUrl { get; set; }
        [JsonProperty("consumable_id")]
        public long ID { get; set; }
        [JsonProperty("price_credit")]
        public long Credits { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

    }
}
