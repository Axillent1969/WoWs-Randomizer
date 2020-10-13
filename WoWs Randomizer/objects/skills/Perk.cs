using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
