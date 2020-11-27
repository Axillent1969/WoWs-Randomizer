using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.player

{
    class PlayerData
    {
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
        [JsonProperty("account_id")]
        public long ID { get; set; }
    }
}
