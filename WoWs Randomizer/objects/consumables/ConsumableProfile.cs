using System;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.consumables
{
    [Serializable]
    public class ConsumableProfile
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
