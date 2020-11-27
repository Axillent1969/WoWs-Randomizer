using System;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.ship.profile
{
    [Serializable]
    public class DefaultProfile
    {
        [JsonProperty("engine")]
        public Engine Engine { get; set; }

        [JsonProperty("mobility")]
        public Mobility Mobility { get; set; }

        [JsonProperty("atbas")]
        public Secondaries Secondaries { get; set; }

        [JsonProperty("artillery")]
        public Artillery Artillery { get; set; }

        [JsonProperty("concealment")]
        public Concealment Concealment { get; set; }
    }
}
