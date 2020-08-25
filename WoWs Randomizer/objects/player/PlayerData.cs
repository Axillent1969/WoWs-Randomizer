using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.player

{
    class PlayerData
    {
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
        [JsonProperty("account_id")]
        public long ID { get; set; }
    }
}
