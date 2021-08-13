using System.Collections.Generic;
using Newtonsoft.Json;
using WoWs_Randomizer.utils.modules;

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
        [JsonProperty("airstrike")]
        public Dictionary<string,ModuleAirstrike> Airstrike { get; set; }
    }
}
