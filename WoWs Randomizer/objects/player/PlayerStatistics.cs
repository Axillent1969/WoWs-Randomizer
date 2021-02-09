using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.player
{
    [Serializable]
    class PlayerStatistics
    {
        [JsonProperty("distance")]
        public long Distance { get; set; }
        [JsonProperty("battles")]
        public long Battles { get; set; }

        [JsonProperty("pvp")]
        public PlayerPVPStatistics PVPStatistics { get; set; }
    }
}
