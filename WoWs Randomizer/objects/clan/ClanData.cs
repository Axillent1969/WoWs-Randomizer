using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.clan
{
    class ClanData
    {
        [JsonProperty("members_count")]
        public long Count { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("crated_at")]
        public long Created { get; set; }
        [JsonProperty("creator_name")]
        public string CreatedBy { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }
        [JsonProperty("leader_name")]
        public string Leader { get; set; }
        [JsonProperty("clan_id")]
        public long ID { get; set; }
        [JsonProperty("members")]
        public Dictionary<string,ClanMember> Members { get; set; }
        [JsonProperty("is_clan_disbanded")]
        public bool IsDisbanded { get; set; }
        [JsonProperty("leader_id")]
        public long LeaderID { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
