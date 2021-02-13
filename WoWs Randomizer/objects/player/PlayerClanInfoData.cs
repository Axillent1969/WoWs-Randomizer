using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.player
{
    class PlayerClanInfoData
    {
        [JsonProperty("clan")]
        public ClanBaseData ClanData { get; set; }
        [JsonProperty("joined_at")]
        public long Joined { get; set; }
        [JsonProperty("clan_id")]
        public long ClanID { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
