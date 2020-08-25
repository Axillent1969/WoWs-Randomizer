using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.ship
{
    [Serializable]
    public class Module
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("next_modules")]
        public List<long> NextModules { get; set; }
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
        [JsonProperty("price_x")] 
        public long PriceXP { get; set; }
        [JsonProperty("price_credit")]
        public long PriceCredit { get; set; }
        
        //Skip next_ships

        [JsonProperty("module_id")]
        public long ID { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("module_id_str")]
        public string ModuleID { get; set; }
    }
}
