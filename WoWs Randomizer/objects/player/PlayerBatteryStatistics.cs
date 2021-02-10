using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.player
{
    [Serializable]
    class PlayerBatteryStatistics
    {
        [JsonProperty("max_frags_battle")]
        public long MaxKilled { get; set; }
        [JsonProperty("frags")]
        public long Kills { get; set; }
        [JsonProperty("hits")]
        public long Hits { get; set; }
        [JsonProperty("max_frags_ship_id")]
        public long MaxKilledShipId { get; set; }
        [JsonProperty("shots")]
        public long ShotsFired { get; set; }

    }
}
