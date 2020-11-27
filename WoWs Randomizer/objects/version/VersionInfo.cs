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
