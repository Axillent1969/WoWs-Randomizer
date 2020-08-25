using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.version

{
    class VersionInfoImport
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public VersionInfo VersionInfo { get; set; }
    }
}
