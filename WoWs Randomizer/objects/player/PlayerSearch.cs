using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.player
{
    class PlayerSearch
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public PlayerData[] Player { get; set; }
    }
}
