using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.player
{
    class ClanBaseData
    {
        [JsonProperty("members_count")]
        public long Count { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
