using System;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.ship.profile
{
    [Serializable]
    public class Concealment
    {
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("detect_distance_by_plane")]
        public double AirDetection { get; set; }
        [JsonProperty("detect_distance_by_ship")]
        public double SurfaceDetection { get; set; }

    }
}
