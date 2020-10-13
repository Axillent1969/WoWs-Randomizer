using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.consumables
{
    class ConsumablesInfoTypeImporter
    {
        [JsonProperty("shipId")] 
        public long ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("duration")]
        public double Duration { get; set;}
        [JsonProperty("range")]
        public double Range { get; set; }
        [JsonProperty("cooldown")]
        public double Cooldown { get; set; }
    }
}
