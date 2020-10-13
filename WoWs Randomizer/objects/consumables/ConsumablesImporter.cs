using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WoWs_Randomizer.utils;

namespace WoWs_Randomizer.objects.consumables
{
    [Serializable]
    public class ConsumablesImporter
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("meta")]
        public MetaData MetaInfo { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, Consumable> Data { get; set; }
    }
}
