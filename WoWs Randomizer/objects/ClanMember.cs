using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects
{
    class ClanMember
    {
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("joined_at")]
        public long MemberSince { get; set; }
        [JsonProperty("account_id")]
        public long ID { get; set; }
        [JsonProperty("account_name")]
        public string Name { get; set; }
    }
}
