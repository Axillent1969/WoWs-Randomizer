using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.ship.profile
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
