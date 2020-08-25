using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.version
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
