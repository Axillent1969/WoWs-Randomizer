using System;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.player

{
    [Serializable]
    class PlayerShip
    {
        [JsonProperty("ship_id")]
        public long ID { get; set; }
    }
}
