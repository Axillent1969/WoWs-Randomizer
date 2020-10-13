using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.consumables
{
    class ConsumablesInfoImporter
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("consumables")]
        public Dictionary<string,List<ConsumablesInfoTypeImporter>> Consumables { get; set; }
    }
}
