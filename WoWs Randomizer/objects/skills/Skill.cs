using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.skills
{
    [Serializable]
    class Skill
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type_id")]
        public int TypeId { get; set; }
        [JsonProperty("type_name")]
        public string Type { get; set; }
        [JsonProperty("perks")]
        public List<Perk> Perks { get; set; }
        [JsonProperty("tier")]
        public int Tier { get; set; }
        [JsonProperty("icon")]
        public string ImageUrl { get; set; }
    }
}
