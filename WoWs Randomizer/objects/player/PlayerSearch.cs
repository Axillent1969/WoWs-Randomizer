using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.player
{
    class PlayerSearch
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public PlayerData[] Player { get; set; }
    }
}
