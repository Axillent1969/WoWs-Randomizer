using System;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.skills
{
    [Serializable]
    class Perk
    {
        [JsonProperty("perkid")]
        public string ID { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }

    }
}
