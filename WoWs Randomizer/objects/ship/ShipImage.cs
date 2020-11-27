using System;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.ship

{
    [Serializable]
    public class ShipImage
    {
        [JsonProperty("small")]
        public string Small { get; set; }
        [JsonProperty("large")]
        public string Large { get; set; }
        [JsonProperty("medium")]
        public string Medium { get; set; }
        [JsonProperty("countour")]
        public string Contour { get; set; }
    }
}
