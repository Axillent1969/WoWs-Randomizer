using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.upgrades
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
