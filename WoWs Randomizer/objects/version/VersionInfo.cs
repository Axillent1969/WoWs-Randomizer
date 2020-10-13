using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.version

{
    class VersionInfo
    {
        [JsonProperty("ships_updated_at")]
        public long Updated { get; set; }
        [JsonProperty("game_version")]
        public string GameVersion { get; set; }
    }
}
