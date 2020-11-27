using System.Collections.Generic;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.player

{
    class PlayerShipImport
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public Dictionary<string, List<PlayerShip>> Ships { get; set; }
    }
}
