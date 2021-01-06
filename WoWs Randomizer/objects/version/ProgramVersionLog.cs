using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.version
{
    public class ProgramVersionLog
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("datetime")]
        public string Date { get; set; }
        [JsonProperty("log")]
        public List<string> Log { get; set; }
    }
}
