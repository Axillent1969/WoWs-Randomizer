using System;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.skills
{
    [Serializable]
    class Perk
    {
        [JsonProperty("perk_id")]
        public int ID { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

    }
}
