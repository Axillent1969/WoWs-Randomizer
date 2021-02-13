using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.player
{
    class PlayerClanInfoImport
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public Dictionary<string, PlayerClanInfoData> Data { get; set; }
    }
}
