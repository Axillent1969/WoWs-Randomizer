using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.player
{
    [Serializable]
    class PlayerAuxilliaryStatistics
    {
        [JsonProperty("max_frags_battle")]
        public long MaxKills { get; set; }

        [JsonProperty("frags")]
        public long Kills { get; set; }
        [JsonProperty("max_frags_ship_id")]
        public long MaxKillsShipId { get; set; }

    }
}
