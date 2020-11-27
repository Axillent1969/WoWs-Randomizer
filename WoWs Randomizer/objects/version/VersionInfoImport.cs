using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.version

{
    class VersionInfoImport
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public VersionInfo VersionInfo { get; set; }
    }
}
