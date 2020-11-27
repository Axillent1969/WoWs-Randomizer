using System.Collections.Generic;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.consumables
{
    class ConsumablesInfoTypeImporter
    {
        [JsonProperty("shipId")] 
        public List<long> ID { get; set; }
        [JsonProperty("groupId")]
        public long Group { get; set; }
        [JsonProperty("exceptions")]
        public List<long> Exceptions { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("duration")]
        public double Duration { get; set;}
        [JsonProperty("range")]
        public double Range { get; set; }
        [JsonProperty("cooldown")]
        public double Cooldown { get; set; }
        [JsonProperty("charges")]
        public int Charges { get; set; }

        [JsonProperty("extrainfo")] 
        public string ExtraInfo { get; set; }
    }
}
