using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.player
{
    [Serializable]
    class PlayerPersonalData
    {
        [JsonProperty("last_battle_time")]
        public long LastBattle { get; set; }
        [JsonProperty("created_at")]
        public long AccountCreated { get; set; }
        [JsonProperty("updated_at")]
        public long LastUpdated { get; set; }
        [JsonProperty("hidden_profile")]
        public bool HiddenProfile { get; set; }

        [JsonProperty("statistics")]
        public PlayerStatistics Statistics { get; set; }
        [JsonProperty("stats_updated_at")]
        public long StatsUpdatedAt { get; set; }
    }
}
