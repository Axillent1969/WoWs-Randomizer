using System.Collections.Generic;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.version
{
    class ProgramVersion
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("datetime")]
        public string Updated { get; set; }
        [JsonProperty("downloadlink")]
        public string URL { get; set; }

        [JsonProperty("changelog")]
        public List<string> ChangeLog { get; set; }
    }
}
